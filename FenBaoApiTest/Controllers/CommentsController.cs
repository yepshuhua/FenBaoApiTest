using AutoMapper;
using FenBaoApiTest.Dtos;
using FenBaoApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Controllers
{
    [Route("api/Activities/{ActivityId}/Comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public CommentsController(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository ??
                throw new ArgumentNullException(nameof(activityRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public IActionResult GetCommentListForActivityRoute(Guid activityId)
        {
            if (!_activityRepository.ActivityExists(activityId))
            {
                return NotFound("目前暂无评论");
            }
            var CommentFromRepo = _activityRepository.GetCommentByActivityId(activityId);
            if (CommentFromRepo == null || CommentFromRepo.Count() <= 0)
            {
                return NotFound("评论不存在");
            }
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(CommentFromRepo));
        }
        [HttpGet("{CommentId}")]
        public IActionResult GetComment(Guid activityId, int commentId)
        {
            if (!_activityRepository.ActivityExists(activityId))
            {
                return NotFound("活动不存在");
            }
            var CommentFromRepo = _activityRepository.GetComment(commentId);
            if (CommentFromRepo == null)
            {
                return NotFound("评论不存在");
            }
            return Ok(_mapper.Map<CommentDto>(CommentFromRepo));
        }

    }
   
}
