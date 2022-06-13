using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bug_Tracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bug_Tracker.Util
{
    public static class UserHelper
    {
        private static ApplicationDbContext db { get; set; }

        static UserHelper()
        {
            db = new ApplicationDbContext();
        }

        public static ApplicationUser GetById(string id)
        {
            return db.Users.ToList().Find(u => u.Id == id);
        }

        public static ApplicationUser GetByName(string name)
        {
            return db.Users.ToList().Find(u => u.UserName == name);
        }

        public static bool IsInRole(ApplicationUser user, string name)
        {
            return db.Roles.ToList().Find(r => user.Roles.ToList().Find(u => u.RoleId == r.Id && r.Name == name) != null) != null;
        }

        public static List<ApplicationUser> FindInRole(string name)
        {
            return db.Users.ToList().Where(u => IsInRole(u, name)).ToList();
        }

        public static void AddRole(ApplicationUser user, string name)
        {
            IdentityRole role = RoleHelper.GetByName(name);
            if (user.Roles.ToList().Find(r => r.UserId == role.Id) == null) user.Roles.Add(new IdentityUserRole() { UserId = user.Id, RoleId = role.Id });
        }

        public static void RemoveRole(ApplicationUser user, string name)
        {
            IdentityRole role = RoleHelper.GetByName(name);
            IdentityUserRole userRole = user.Roles.ToList().Find(r => r.RoleId == role.Id);
            user.Roles.Remove(userRole);
        }
    }
}