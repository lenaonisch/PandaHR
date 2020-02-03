﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class CVRepository : EFRepositoryAsync<CV>, ICVRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CVRepository(ApplicationDbContext context, IMapper mapper) :
            base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CV> GetById(Guid id)
        {
            var CV = await _context.CVs.Where(j => j.Id == id).FirstAsync();
            return CV;
        }

        public async Task<IEnumerable<CVSummaryDTO>> GetUserCVSummaryAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            IEnumerable<CV> query = await _context.CVs.Where(cv => cv.UserId == userId)
                .Include(c => c.Qualification)
                .Include(c => c.Technology)
                .ToListAsync();

            if (pageSize != null && page != null)
            {
                query = query.Skip((int)pageSize * ((int)page - 1)).Take((int)pageSize);
            }

            return _mapper.Map<IEnumerable<CV>, IEnumerable<CVSummaryDTO>>(query);
        }

        public async Task<IEnumerable<CVforSearchDTO>> GetCVsAsync(Expression<Func<CV, bool>> predicate,/*Guid userId,*/ int? pageSize = 10, int? page = 1)
        {
            IEnumerable<CV> query = await _context.CVs.Where(predicate)
                .Include(c => c.Qualification)
                .Include(c => c.Technology)
                .Include(cc => cc.SkillKnowledges)
                    .ThenInclude(c => c.KnowledgeLevel)
                        .ThenInclude(k=>k.SkillKnowledgeTypes)
                        //.Where(t=>t.UserId ==userId)
                .Include(cc => cc.SkillKnowledges)
                    .ThenInclude(c => c.Skill)
                        .ThenInclude(s => s.SkillType)
                            .ThenInclude(t => t.SkillKnowledgeTypes)
                .ToListAsync();

            IEnumerable<CVforSearchDTO> query1 =
                from t in query
                select new CVforSearchDTO()
                {
                    Id = t.Id,
                    IsActive = t.IsActive,
                    TechnologyName = t.Technology.Name,
                    QualificationName = t.Qualification.Name,
                    QualificationValue = t.Qualification.Value,
                    Summary = t.Summary,
                    UserId = t.UserId,
                    SkillKnowledges = (from s in t.SkillKnowledges
                                    select new SkillForSearchDTO()
                                    {
                                        SkillName = s.Skill.Name,
                                        KnowledgeLevelName = s.KnowledgeLevel.Name,
                                        KnowledgeValueValue = s.KnowledgeLevel.SkillKnowledgeTypes.FirstOrDefault().Value
                                    }).ToHashSet()
                };

            if (pageSize != null && page != null)
            {
                query1 = query1.Skip((int)pageSize * ((int)page-1)).Take((int)pageSize);
            }
            
            return query1;
        }
    }
}
