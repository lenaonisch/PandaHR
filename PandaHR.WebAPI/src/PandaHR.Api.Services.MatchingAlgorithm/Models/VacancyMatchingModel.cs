﻿using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Models
{
    public class VacancyMatchingModel : ISkillSetModel<Guid>
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> Skills { get; set; }
    }
}
