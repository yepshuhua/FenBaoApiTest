using AutoMapper;
using FenBaoApiTest.Dtos;
using FenBaoApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenBaoApiTest.Models;

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
        [HttpGet("{CommentId}", Name = "GetComment")]
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
        [HttpPost]
        public IActionResult CreateComment([FromRoute] Guid activityId, [FromBody] CommentCreateDto commentCreateDto)
        {
            if (!_activityRepository.ActivityExists(activityId))
            {
                return NotFound("活动不存在");
            }

            var CommentModel = _mapper.Map<Comment>(commentCreateDto);
            _activityRepository.AddComment(activityId, CommentModel);
            _activityRepository.Save();
            var CommentReturn = _mapper.Map<CommentDto>(CommentModel);
            return CreatedAtRoute("GetComment",
                new { activityId = CommentModel.ActivityId, CommentId = CommentModel.Id },
                CommentReturn);
        }
        [HttpDelete("{CommentId}")]
        public IActionResult DeleteComment([FromRoute]Guid activityId,[FromRoute]int commentId)
        {
            if (!_activityRepository.ActivityExists(activityId))
            {
                return NotFound("活动不存在");
            }
            var comment = _activityRepository.GetComment(commentId);
            _activityRepository.DeleteComment(comment);
            _activityRepository.Save();
            return NoContent();
        }
    }
   
}
