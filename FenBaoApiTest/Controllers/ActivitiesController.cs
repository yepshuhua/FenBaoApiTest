﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenBaoApiTest.Dtos;
using FenBaoApiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace FenBaoApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public ActivitiesController(IActivityRepository activityRepository,IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [HttpHead]
        public IActionResult GetActivity([FromQuery]string keyword)
        {
            var activityRoutesFromRepo = _activityRepository.GetActivities(keyword);
            if (activityRoutesFromRepo == null || activityRoutesFromRepo.Count() <= 0 )
            {
                return NotFound("未找到活动");
            }
            var activitiesdto = _mapper.Map<IEnumerable<ActivitiesDto>>(activityRoutesFromRepo);
            return Ok(activitiesdto);
        }
        [HttpGet("{ActivityId}")]
        [HttpHead]
        public IActionResult GetActivityById(Guid ActivityId)
        {
            var activityRoutesFromRepo = _activityRepository.GetActivity(ActivityId);
            if (activityRoutesFromRepo == null )
            {
                return NotFound("未找到对应活动");
            }
            var activitiesdto = _mapper.Map<ActivitiesDto>(activityRoutesFromRepo);
            return Ok(activitiesdto);
        }
    }
}
