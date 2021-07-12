using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class TopicReplyRating
    {
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("RatedReply"), Column(Order = 0)]
        public int TopicReplyId { get; set; }

        [ForeignKey("RatedReply"), Column(Order = 1)]
        public int TopicId { get; set; }

        public virtual TopicReply TopicReply { get; set; }

        public bool IsLike { get; set; }
    }
}
