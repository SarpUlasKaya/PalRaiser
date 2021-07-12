using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Body { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int CommentCount { get; set; }

        [ForeignKey("PublisherId")]
        public virtual AppUser Publisher { get; set; }
        public int? PublisherId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostRating> Ratings { get; set; }
    }
}
