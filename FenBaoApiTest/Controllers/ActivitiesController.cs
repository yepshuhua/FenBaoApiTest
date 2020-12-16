using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenBaoApiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FenBaoApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IActivityRepository _activityRepository;
        public ActivitiesController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        [HttpGet]
        public IActionResult GetActivity()
        {
            var activityRoutesFromRepo = _activityRepository.GetActivities();
            if (activityRoutesFromRepo == null || activityRoutesFromRepo.Count() <= 0 )
            {
                return NotFound("未找到活动");
            }
            return Ok(activityRoutesFromRepo);
        }
        [HttpGet("{ActivityId}")]
        public IActionResult GetActivityById(Guid ActivityId)
        {
            var activityRoutesFromRepo = _activityRepository.GetActivity(ActivityId);
            if (activityRoutesFromRepo == null )
            {
                return NotFound("未找到对应活动");
            }
            return Ok(activityRoutesFromRepo);
        }
    }
}
