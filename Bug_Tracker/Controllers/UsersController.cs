using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bug_Tracker.Models;
using Bug_Tracker.Util;

namespace Bug_Tracker.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db { get; set; }

        public UsersController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Details(string id)
        {
            return View(UserHelper.GetById(id));
        }
    }
}