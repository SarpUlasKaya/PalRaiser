using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string ProjName { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Type { get; set; }
        
        public int AmountRaised { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int ReportCount { get; set; }

        [ForeignKey("PublisherId")]
        public virtual User Publisher { get; set; }
        public int? PublisherId { get; set; }
        
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Update> Updates { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
