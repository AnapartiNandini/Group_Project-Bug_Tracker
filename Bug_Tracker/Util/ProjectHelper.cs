using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bug_Tracker.Models;

namespace Bug_Tracker.Util
{
    public static class ProjectHelper
    {
        private static ApplicationDbContext db { get; set; }

        static ProjectHelper()
        {
            db = new ApplicationDbContext();
        }

        public static Project Get(int Id)
        {
            return db.Projects.ToList().Find(p => p.Id == Id);
        }

        public static Project Create(ApplicationUser user, string name)
        {
            Project pro = new Project() { Manager = user, ManagerId = user.Id, Name = name };
            db.Projects.Add(pro);
            db.SaveChanges();
            return pro;
        }

        public static Project Edit(int Id, string name)
        {
            Project pro = Get(Id);
            pro.Name = name;
            db.SaveChanges();
            return pro;
        }

        public static void AddUser(int Id, ApplicationUser user)
        {
            Project pro = Get(Id);
            pro.Users.Add(new ProjectUser() { Project = pro, ProjectId = Id, User = user, UserId = user.Id });
            db.SaveChanges();
        }

        public static void RemoveUser(int Id, ApplicationUser user)
        {
            Project pro = Get(Id);
            ProjectUser pu = pro.Users.Find(u => u.UserId == user.Id);
            pro.Users.Remove(pu);
            db.SaveChanges();
        }
    }
}