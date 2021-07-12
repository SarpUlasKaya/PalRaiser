﻿using System;
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

        public virtual Comment Comment { get; set; }

        [ForeignKey("CommentId"), Column(Order = 0)]
        public int CommentId { get; set; }

        [ForeignKey("CommentId"), Column(Order = 1)]
        public int PostId { get; set; }

        public bool IsLike { get; set; }
    }
}
