﻿using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllAsync();
        Task<Skill> GetById(Guid id);
        Task Add(Skill skill);
        Task Update(Skill skill);
        Task Remove(Skill skill);
    }
}
