using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Dtos
{
    public class ActivitiesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal ActivityScore { get; set; }
        public int? ParticipantsNum { get; set; }
        public DateTime? ActivityTime { get; set; }
        public DateTime? ActivityEndTime { get; set; }
        public string ActivtyAddress { get; set; }
        public bool ActivtyStatus { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
