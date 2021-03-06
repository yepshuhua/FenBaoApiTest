﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace FenBaoApiTest.Dtos
{

    public class ActivityCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ActivityScore { get; set; }
        public int? ParticipantsNum { get; set; }
        public DateTime? ActivityTime { get; set; }
        public DateTime? ActivityEndTime { get; set; }
        public string ActivtyAddress { get; set; }
        public bool ActivtyStatus { get; set; }
        public ICollection<CommentCreateDto> Comments { get; set; }
        = new List<CommentCreateDto>();
    }
}
