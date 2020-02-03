﻿using System;
using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    public class VacancyAlghorythmModel
    {
        public VacancyAlghorythmModel()
        {
            SkillRequests = new List<SkillRequestAlghorythmModel>();
        }

        public List<SkillRequestAlghorythmModel> SkillRequests { get; set; }
        public Guid Id { get; set; }
        public int Qualification { get; set; }

    }
}
