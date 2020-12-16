using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public Guid StudentId { get; set; }
        /// <summary>
        /// 活动ID
        /// </summary>

        public Guid ActivityId { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public string CommentText { get; set; }
    }
}
