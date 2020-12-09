using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FenBaoApiTest.Models
{
    public class Activity
    {
        [Key]
        /// <summary>
        /// 活动ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 活动名称 
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 活动分值
        /// </summary>
        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal ActivityScore { get; set; }

        /// <summary>
        /// 活动人数
        /// </summary>
        public int? ParticipantsNum { get; set; }

        /// <summary>
        /// 活动评论
        /// </summary>
        [MaxLength(50)]
        public string Comment { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime? ActivityTime { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime? ActivityEndTime { get; set; }

        /// <summary>
        /// 活动地址
        /// </summary>
        public string ActivtyAddress { get; set; }
        
        /// <summary>
        /// 活动状态
        /// </summary>
        public bool ActivtyStatus { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}
