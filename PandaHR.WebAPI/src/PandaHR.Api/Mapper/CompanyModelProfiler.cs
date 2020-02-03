﻿using PandaHR.Api.Common;
using PandaHR.Api.Models.Company;
using PandaHR.Api.Services.Models.Company;

namespace PandaHR.Api.Mapper
{
    public class CompanyModelProfiler : AutoMapperProfile
    {
        public CompanyModelProfiler()
        {
            CreateMap<CompanyBasicInfoResponse, CompanyBasicInfoServiceModel>();

            CreateMap<CompanyBasicInfoServiceModel, CompanyBasicInfoResponse>();
        }
    }
}
