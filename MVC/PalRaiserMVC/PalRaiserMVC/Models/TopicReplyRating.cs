using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class TopicReplyRating
    {
        [Key]
        public int TopicReplyRatingId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("TopicReplyId")]
        public virtual TopicReply TopicReply { get; set; }
        public int TopicReplyId { get; set; }

        public bool IsLike { get; set; }
    }
}
