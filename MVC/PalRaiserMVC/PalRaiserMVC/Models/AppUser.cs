using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [Required]
        public int CardSecNo { get; set; }
        [Required]
        public DateTime CardExpDate { get; set; }

        public DateTimeOffset LastLogin { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Project> PublishedProjects { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Topic> TopicsCreated { get; set; }
        public virtual ICollection<TopicReply> TopicReplies { get; set; }
        public virtual ICollection<ProjectRating> ProjectRatings { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TopicRating> TopicRatings { get; set; }
        public virtual ICollection<TopicReplyRating> TopicReplyRatings { get; set; }
        public virtual ICollection<PostRating> PostRatings { get; set; }
        public virtual ICollection<CommentRating> CommentRatings { get; set; }
    }
}
