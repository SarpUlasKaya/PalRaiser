using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTimeOffset Date { get; set; }
        
        [Required]
        public string Reason { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
