using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class CommentRating
    {
        [Key]
        public int CommentRatingId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("CommentId"), Column(Order = 0)]
        public virtual Comment Comment { get; set; }
        public int CommentId { get; set; }

        public bool IsLike { get; set; }
    }
}
