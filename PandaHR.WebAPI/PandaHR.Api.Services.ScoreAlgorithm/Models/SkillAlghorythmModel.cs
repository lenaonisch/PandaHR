﻿using System;
using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlgorithm.Models
{
    public class SkillAlghorythmModel
    {
        public SkillAlghorythmModel()
        {
            SupSkills = new List<SkillAlghorythmModel>();
        }
        public Guid Id { get; set; }
        public int SkillType { get; set; }
        public List<SkillAlghorythmModel> SupSkills { get; set; }
    }
}