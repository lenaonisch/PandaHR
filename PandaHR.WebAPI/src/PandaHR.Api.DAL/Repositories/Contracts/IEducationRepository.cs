﻿using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IEducationRepository : IAsyncRepository<Education>
    {
        Task<ICollection<EducationNameDTO>> GetBasicInfoByAutofillByName(string name);
    }
}
