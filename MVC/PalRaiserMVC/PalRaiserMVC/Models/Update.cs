using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class Update
    {
        public int UpdateId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }

        [Required]
        public int Title { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
