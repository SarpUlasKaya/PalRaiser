using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Project
    {
        [Key]
        public int ProjId { get; set; }

        [Required]
        public string ProjName { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Type { get; set; }
        
        public string AmountRaised { get; set; }
        public string LikeCount { get; set; }
        public string DislikeCount { get; set; }
        public string ReportCount { get; set; }
    }
}
