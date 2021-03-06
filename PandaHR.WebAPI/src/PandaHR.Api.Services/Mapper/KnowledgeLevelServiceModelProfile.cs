﻿using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.KnowledgeLevel;
using PandaHR.Api.Services.Models.KnowledgeLevel;

namespace PandaHR.Api.Services.Mapper
{
    public class KnowledgeLevelServiceModelProfile : AutoMapperProfile
    {
        public KnowledgeLevelServiceModelProfile()
        {
            CreateMap< KnowledgeLevel, KnowledgeLevelServiceModel>();
            CreateMap<KnowledgeLevelServiceModel, KnowledgeLevelDTO>();
            CreateMap<KnowledgeLevelDTO, KnowledgeLevelServiceModel>();
        }
    }
}
