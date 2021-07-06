using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserRazor.Model
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
        public string DetailedInfo { get; set; }
        [Required]
        public string Type { get; set; }
        
        public int? AmountRaised { get; set; }
        public int? LikeCount { get; set; }
        public int? DislikeCount { get; set; }
        public int? ReportCount { get; set; }
        public int? TestValue { get; set; }

    }
}
