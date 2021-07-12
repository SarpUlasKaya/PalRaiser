using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class TopicRating
    {
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }
        public int? TopicId { get; set; }

        public bool IsLike { get; set; }
    }
}
