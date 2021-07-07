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

        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string ReplyBody { get; set; }

        public DateTimeOffset Date { get; set; }

        public virtual User User { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
