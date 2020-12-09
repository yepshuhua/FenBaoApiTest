﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Models
{
    public class Comment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public Guid Id { get; set; }
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

        public Activity activity { get; set; }
    }
}