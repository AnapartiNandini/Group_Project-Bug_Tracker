using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bug_Tracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bug_Tracker.Util
{
    public static class RoleHelper
    {
        private static ApplicationDbContext db { get; set; }

        static RoleHelper()
        {
            db = new ApplicationDbContext();
        }

        public static IdentityRole GetById(string id)
        {
            return db.Roles.ToList().Find(r => r.Id == id);
        }

        public static IdentityRole GetByName(string name)
        {
            return db.Roles.ToList().Find(r => r.Name == name);
        }
    }
}