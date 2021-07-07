using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("User")]
        public int CreatorId { get; set; }

        [Required]
        public string TopicTitle { get; set; }
        [Required]
        public string TopicBody { get; set; }

        public DateTimeOffset Date { get; set; }
        public int NoOfReplies { get; set; }
        
        public virtual User Creator { get; set; }
        public virtual Project Project { get; set; }
    }
}
