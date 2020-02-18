﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.Qualification;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Qualification;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public QualificationController(IQualificationService qualificationService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _mapper = mapper;
        }

        // GET: api/Qualification
        [HttpGet]
        public async Task<IEnumerable<QualificationResponseModel>> GetAllQualifications()
        {
            var serviceModels = await _qualificationService.GetAllQualificationsAsync();

            return _mapper
               .Map<IEnumerable<QualificationServiceModel>, IEnumerable<QualificationResponseModel>>(serviceModels);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Qualification qualification)
        {
            await _qualificationService.AddAsync(qualification);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, Qualification qualification)
        {
            await _qualificationService.UpdateAsync(qualification);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _qualificationService.RemoveAsync(id);

            return Ok();
        }
    }
}
