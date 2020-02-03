﻿using PandaHR.Api.Services.Models.SkillRequirement;
using System;
using System.Collections.Generic;

namespace PandaHR.Api.Services.Models.Vacancy
{
    public class VacancyServiceModel
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CityId { get; set; }
        public ICollection<SkillRequirementServiceModel> SkillRequirements { get; set; }
        public Guid TechnologyId { get; set; }
        public Guid QualificationId { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
