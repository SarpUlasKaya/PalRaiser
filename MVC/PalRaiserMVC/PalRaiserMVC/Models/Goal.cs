using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Goal
    {
        public int GoalId { get; set; }
        
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
        
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Description { get; set; }

        public bool IsReached { get; set; }
    }
}
