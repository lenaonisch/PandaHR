﻿using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Exporter.Models.ExportModels;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillServiceModelProfile : AutoMapperProfile
    {
        public SkillServiceModelProfile()
        {
            CreateMap<SkillNameDTO, SkillNameServiceModel>();
            CreateMap<Skill, SkillServiceModel>();
            CreateMap<Skill, SkillNameServiceModel>();
            CreateMap<SkillExportDTO, SkillExportModel>();

            CreateMap<SkillNameServiceModel, Skill>();
        }
    }
}
