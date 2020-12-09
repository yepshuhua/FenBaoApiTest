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
        public IActionResult GetActivity()
        {
            var routes = _activityRepository.GetActivities();
            return Ok(routes);
        }
    }
}
