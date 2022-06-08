namespace Bug_Tracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
<<<<<<< HEAD
    using Microsoft.AspNet.Identity.EntityFramework;
    using Bug_Tracker.Models;
    using Microsoft.AspNet.Identity;
=======
>>>>>>> f62a318e4d909abcf1a1ba3d186bfdcb5e4ec6e0

    internal sealed class Configuration : DbMigrationsConfiguration<Bug_Tracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

<<<<<<< HEAD
        protected async override void Seed(Bug_Tracker.Models.ApplicationDbContext context)
=======
        protected override void Seed(Bug_Tracker.Models.ApplicationDbContext context)
>>>>>>> f62a318e4d909abcf1a1ba3d186bfdcb5e4ec6e0
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
<<<<<<< HEAD

            context.Roles.AddOrUpdate(new IdentityRole() { Id = "0", Name = "Submitter" });
            context.Roles.AddOrUpdate(new IdentityRole() { Id = "1", Name = "Developer" });
            context.Roles.AddOrUpdate(new IdentityRole() { Id = "2", Name = "Project Manager" });
            context.Roles.AddOrUpdate(new IdentityRole() { Id = "3", Name = "Admin" });

            context.TicketPriorities.AddOrUpdate(new TicketPriority() { Id = 0, Name = "Optional" });
            context.TicketPriorities.AddOrUpdate(new TicketPriority() { Id = 1, Name = "Normal" });
            context.TicketPriorities.AddOrUpdate(new TicketPriority() { Id = 2, Name = "Urgent" });
            context.TicketPriorities.AddOrUpdate(new TicketPriority() { Id = 3, Name = "Important" });

            context.TicketTypes.AddOrUpdate(new TicketType() { Id = 0, Name = "Bug" });

            context.TicketStatuses.AddOrUpdate(new TicketStatus() { Id = 0, Name = "Reported" });
            context.TicketStatuses.AddOrUpdate(new TicketStatus() { Id = 1, Name = "In Progress" });
            context.TicketStatuses.AddOrUpdate(new TicketStatus() { Id = 2, Name = "Resolved" });
=======
>>>>>>> f62a318e4d909abcf1a1ba3d186bfdcb5e4ec6e0
        }
    }
}
