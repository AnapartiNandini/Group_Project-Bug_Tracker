using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bug_Tracker.Models;
using Bug_Tracker.Util;
using Microsoft.AspNet.Identity;

namespace Bug_Tracker.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db { get; set; }

        public ProjectsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult Details(int Id)
        {
            return View(ProjectHelper.Get(Id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name)
        {
            if (!User.IsInRole("Project Manager") & !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Projects");
            }
            Project pro = ProjectHelper.Create(UserHelper.GetById(User.Identity.GetUserId()), name);
            return RedirectToAction("Details", "Projects", new { Id = pro.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Project pro = ProjectHelper.Get(id);
            db.Projects.Remove(pro);
            return RedirectToAction("Index", "Projects");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string name)
        {
            Project pro = ProjectHelper.Get(id);
            if (!User.IsInRole("Project Manager") & !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Projects");
            }
            if (User.IsInRole("Project Manager") && pro.ManagerId == User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Projects");
            }
            ProjectHelper.Edit(id, name);

            return RedirectToAction("Details", "Projects", new { Id = id });
        }
    }
}