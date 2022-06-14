using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bug_Tracker.Models;

namespace Bug_Tracker.Util
{
    public static class TicketHelper
    {
        private static ApplicationDbContext db { get; set; }

        static TicketHelper()
        {
            db = new ApplicationDbContext();
        }

        public static Ticket GetTicket(int Id)
        {
            return db.Tickets.ToList().Find(t => t.Id == Id);
        }

        public static TicketStatus GetStatus(int Id)
        {
            return db.TicketStatuses.ToList().Find(s => s.Id == Id);
        }

        public static TicketPriority GetPriority(int Id)
        {
            return db.TicketPriorities.ToList().Find(p => p.Id == Id);
        }

        public static TicketType GetType(int Id)
        {
            return db.TicketTypes.ToList().Find(t => t.Id == Id);
        }

        public static Ticket Create(ApplicationUser owner, string title, string content, TicketType type, TicketPriority priority)
        {
            Ticket tic = new Ticket();
            tic.Owner = owner;
            return Edit(tic.Id, title, content, type, priority, GetStatus(1));
        }

        public static Ticket Edit(int Id, string title, string content, TicketType type, TicketPriority priority, TicketStatus status)
        {
            Ticket tic = GetTicket(Id);
            tic.Title = title;
            tic.Content = content;
            tic.Type = type;
            tic.Priority = priority;
            tic.Status = status;

            db.SaveChanges();
            return tic;
        }

        public static Ticket Assign(ApplicationUser user, int Id)
        {
            Ticket tic = GetTicket(Id);
            tic.AssignedDev = user;
            return tic;
        }
    }
}