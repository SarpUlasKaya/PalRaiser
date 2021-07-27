using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class TopicReply
    {
        [Key]
        public int TopicReplyId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }
        public int TopicId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public int? UserId { get; set; }

        [Required]
        public string ReplyBody { get; set; }

        public DateTimeOffset Date { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        public virtual ICollection<TopicReplyRating> Ratings { get; set; }
    }
}
