using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenBaoApiTest.Dtos;
using FenBaoApiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FenBaoApiTest.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace FenBaoApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public ActivitiesController(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [HttpHead]
        public IActionResult GetActivity([FromQuery] string keyword, string rating)
        {
            var activityRoutesFromRepo = _activityRepository.GetActivities(keyword);
            if (activityRoutesFromRepo == null || activityRoutesFromRepo.Count() <= 0)
            {
                return NotFound("未找到活动");
            }
            var activitiesdto = _mapper.Map<IEnumerable<ActivitiesDto>>(activityRoutesFromRepo);
            return Ok(activitiesdto);
        }
        [HttpGet("{ActivityId}",Name = "GetActivityById")]
        [HttpHead]
        public IActionResult GetActivityById(Guid ActivityId)
        {
            var activityRoutesFromRepo = _activityRepository.GetActivity(ActivityId);
            if (activityRoutesFromRepo == null)
            {
                return NotFound("未找到对应活动");
            }
            var activitiesdto = _mapper.Map<ActivitiesDto>(activityRoutesFromRepo);
            return Ok(activitiesdto);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes ="Bearer")]
        [Authorize(Roles ="Admin")]
        public IActionResult CreateActivity([FromBody] ActivityCreateDto activityCreateDto )
        {
            var activitymodel = _mapper.Map<Activity>(activityCreateDto);
            _activityRepository.AddActivity(activitymodel);
            _activityRepository.Save();
            var activitytoReture = _mapper.Map<ActivitiesDto>(activitymodel);
            return CreatedAtRoute("GetActivityById", new { activityId = activitytoReture.Id }, activitytoReture);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateActivity([FromRoute]Guid activityId,[FromBody] ActivityUpdateDto activityUpdateDto)
        {
            if (!_activityRepository.ActivityExists(activityId))
            {
                return NotFound("未找到对应活动");
            }
            var activityFromRepo = _activityRepository.GetActivity(activityId);
            _mapper.Map(activityUpdateDto, activityFromRepo);
            _activityRepository.Save();
            return NoContent();
        }
        [HttpPatch]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public IActionResult PartiallyUpdateActivity([FromRoute] Guid activityId,[FromBody]JsonPatchDocument<ActivityUpdateDto> patchDocument) 
        {
            if (!_activityRepository.ActivityExists(activityId))
            {
                return NotFound("未找到对应活动");
            }
            var activityFromRepo= _activityRepository.GetActivity(activityId);
            var activitypatch = _mapper.Map<ActivityUpdateDto>(activityFromRepo);
            patchDocument.ApplyTo(activitypatch);
            _mapper.Map(activitypatch, activityFromRepo);
            _activityRepository.Save();
            return NoContent();
        }
        [HttpDelete("{activityId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteActivity([FromRoute] Guid activityId)
        {
            if (!_activityRepository.ActivityExists(activityId))
            {
                return NotFound("未找到对应活动");
            }
            var Activity= _activityRepository.GetActivity(activityId);
            _activityRepository.DeleteActivity(Activity);
            _activityRepository.Save();

            return NoContent();
        }
    }
}
