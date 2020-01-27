﻿using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class SkillRequirementService : ISkillRequirementService
    {
        private readonly IUnitOfWork _uow;

        public SkillRequirementService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(SkillRequirement skillRequirement)
        {
            await _uow.SkillRequirements.Add(skillRequirement);
        }

        public async Task<IEnumerable<SkillRequirement>> GetAllAsync()
        {
            return await _uow.SkillRequirements.GetAllAsync();
        }

        public async Task<SkillRequirement> GetByIdAsync(Guid id)
        {
            return (await _uow.SkillRequirements.GetWhere(s => s.Id == id)).FirstOrDefault();
        }

        public async Task RemoveAsync(Guid id)
        {
            var skillRequirement = (await _uow.SkillRequirements.GetWhere(s => s.Id == id)).FirstOrDefault();
            if(skillRequirement != null)
            {
                await _uow.SkillRequirements.Remove(skillRequirement);
            }
        }

        public async Task UpdateAsync(SkillRequirement skillRequirement)
        {
            if (skillRequirement != null)
            {
                await _uow.SkillRequirements.Update(skillRequirement);
            }
        }
    }
}
