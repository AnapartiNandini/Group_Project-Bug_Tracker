using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public string Content { get; set; }
        public string AssignedDevId { get; set; }
        public virtual ApplicationUser AssignedDev { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public TicketStatus Status { get; set; }
        public string Type { get; set; }
        public Priority Priority { get; set; }
        public virtual List<TicketComment> Comments { get; set; }
        public virtual List<TicketAttatchment> Attatchments { get; set; }

        public Ticket()
        {
            Comments = new List<TicketComment>();
            Attatchments = new List<TicketAttatchment>();
        }
    }
}