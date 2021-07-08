using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class ApplicationUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string MailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [Required]
        public int CardSecNo { get; set; }
        [Required]
        public int CardExpDate { get; set; }

        public DateTimeOffset LastLogin { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Project> PublishedProjects { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Topic> TopicsCreated { get; set; }
        public virtual ICollection<TopicReply> TopicReplies { get; set; }
    }
}
