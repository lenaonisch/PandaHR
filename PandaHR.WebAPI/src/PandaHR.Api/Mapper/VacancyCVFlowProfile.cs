﻿using PandaHR.Api.Common;
using PandaHR.Api.Models.VacancyCVFlow;
using PandaHR.Api.Services.Models.VacancyCVFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Mapper
{
    public class VacancyCVFlowProfile : AutoMapperProfile
    {
        public VacancyCVFlowProfile()
        {
            CreateMap<VacancyCVFlowServiceModel, VacancyCVFlowResponceModel>();
        }
    }
}
