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
        public int StatusId { get; set; }
        public virtual TicketStatus Status { get; set; }
        public int TypeId { get; set; }
        public virtual TicketType Type { get; set; }
        public int PriorityId { get; set; }
        public virtual TicketPriority Priority { get; set; }
        public virtual List<TicketComment> Comments { get; set; }
        public virtual List<TicketAttatchment> Attatchments { get; set; }
        public virtual List<TicketHistory> History { get; set; }

        public Ticket()
        {
            Comments = new List<TicketComment>();
            Attatchments = new List<TicketAttatchment>();
            History = new List<TicketHistory>();
        }
    }
}