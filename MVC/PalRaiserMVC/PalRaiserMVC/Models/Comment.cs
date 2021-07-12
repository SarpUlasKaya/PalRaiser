using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [ForeignKey("CommentorId")]
        public virtual AppUser Commentor { get; set; }
        public int? CommentorId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public int PostId { get; set; }

        [Required]
        public string Body { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}
