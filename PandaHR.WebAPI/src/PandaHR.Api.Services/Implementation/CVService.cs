﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using Nest;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IElasticClient _elasticClient;

        public CVService(IUnitOfWork uow, IMapper mapper, IElasticClient elasticClient)
        {
            _uow = uow;
            _mapper = mapper;
            _elasticClient = elasticClient;
        }

        public async Task AddAsync(CV entity)
        {
            await _uow.CVs.Add(entity);
            await _elasticClient.IndexDocumentAsync(_mapper.Map<CV, CVforSearchDTO>(entity));
        }

        public async Task<IEnumerable<CV>> GetAllAsync()
        {
            return await _uow.CVs.GetAllAsync();
        }

        public async Task<CV> GetByIdAsync(Guid id)
        {
            return await _uow.CVs.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CVSummaryDTO>> GetUserCVsPreviewAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            return await _uow.CVs.GetUserCVSummaryAsync(userId, pageSize, page);
        }

        public async Task<IEnumerable<CVforSearchDTO>> GetUserCVsAsync(Guid userId, int? pageSize = 10, int? page = 1)
        {
            return await _uow.CVs.GetCVsAsync(cv => cv.UserId == userId, pageSize, page);
        }

        public async Task<IEnumerable<CVforSearchDTO>> GetCVsForSearchAsync()
        {
            return await _uow.CVs.GetCVsAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var CV = await GetByIdAsync(id);
            await RemoveAsync(CV);
        }

        public async Task RemoveAsync(CV entity)
        {
            await _uow.CVs.Remove(entity);
            CVforSearchDTO mappedCV = _mapper.Map<CV, CVforSearchDTO>(entity);
            await _elasticClient.DeleteAsync<CVforSearchDTO>(mappedCV);
        }

        public async Task UpdateAsync(CV entity)
        {
            await _uow.CVs.Update(entity);
            CVforSearchDTO mappedCV = _mapper.Map<CV, CVforSearchDTO>(entity);
            await _elasticClient.UpdateAsync<CVforSearchDTO>(mappedCV, u => u.Doc(mappedCV));
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? pageSize = 10, int? page = 1)
        {
            CVforSearchDTO cv = (await _uow.CVs.GetCVsAsync(cv => cv.Id == CVId, pageSize, page)).FirstOrDefault();
            var result = await _uow.Vacancies.GetAllAsync(predicate: v => MatchVacancyCV.Matches(v, cv));

            return _mapper.Map<IList<Vacancy>, IList<VacancySummaryDTO>>(result);
        }
    }
}
