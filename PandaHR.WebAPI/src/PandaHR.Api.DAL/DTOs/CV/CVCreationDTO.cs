﻿using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.DTOs.User;

namespace PandaHR.Api.DAL.DTOs.CV
{
    public class CVCreationDTO
    {
        public UserDTO User { get; set; }
        public ICollection<EducationWithDetailsDTO> Educations { get; set; }
        public string Summary { get; set; }
        public ICollection<SkillKnowledgeDTO> SkillKnowledges { get; set; }
        public ICollection<JobExperienceDTO> JobExperiences { get; set; }
        public Guid TechnologyId { get; set; }
        public Guid QualificationId { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
