using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class PostRating
    {
        [Key]
        public int PostRatingId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public int PostId { get; set; }

        public bool IsLike { get; set; }
    }
}
