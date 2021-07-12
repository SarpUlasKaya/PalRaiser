using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class CommentRating
    {
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
        public int? CommentId { get; set; }

        public bool IsLike { get; set; }
    }
}
