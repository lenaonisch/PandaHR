﻿using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class CompanyDTOProfile : AutoMapperProfile
    {
        public CompanyDTOProfile()
        {
            CreateMap<CompanyNameDTO, Company>();

            CreateMap<Company, CompanyNameDTO>();
        }
    }
}
