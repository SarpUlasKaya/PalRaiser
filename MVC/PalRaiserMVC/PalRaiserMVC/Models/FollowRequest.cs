using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class FollowRequest
    {
        [ForeignKey("SenderId")]
        public virtual AppUser Sender { get; set; }
        public int? SenderId { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual AppUser Receiver { get; set; }
        public int? ReceiverId { get; set; }

        public bool IsAccepted { get; set; }
    }
}
