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
using PandaHR.Api.Services.Models.CV;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CVService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(CVCreationServiceModel cvServiceModel)
        {
            CVDTO cv = _mapper.Map<CVCreationServiceModel, CVDTO>(cvServiceModel);

            await _uow.CVs.AddAsync(cv);
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

        public async Task RemoveAsync(Guid id)
        {
            var CV = await GetByIdAsync(id);
            await RemoveAsync(CV);
        }

        public async Task RemoveAsync(CV entity)
        {
            await _uow.CVs.Remove(entity);
        }

        public async Task UpdateAsync(CV entity)
        {
            await _uow.CVs.Update(entity);
        }

        public async Task<IEnumerable<VacancySummaryDTO>> GetVacanciesForCV(Guid CVId, int? pageSize = 10, int? page = 1)
        {
            CVforSearchDTO cv = (await _uow.CVs.GetCVsAsync(cv => cv.Id == CVId, pageSize, page)).FirstOrDefault();
            var result = (await _uow.Vacancies.GetAllAsync()).Where(v => MatchVacancyCV.Matches(v, cv) > 0);

            return _mapper.Map<IEnumerable<Vacancy>, IEnumerable<VacancySummaryDTO>>(result);
        }
    }
}
