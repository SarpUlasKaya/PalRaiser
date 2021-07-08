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
        public int ReplyId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }
        public int TopicId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int? UserId { get; set; }

        [Required]
        public string ReplyBody { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
