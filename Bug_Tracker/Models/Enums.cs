using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public enum TicketStatus
    {
        Reported,
        InProgress,
        Resolved
    }

    public enum Priority
    {
        Optional,
        Normal,
        Desireable,
        Important,
        Urgent
    }
}