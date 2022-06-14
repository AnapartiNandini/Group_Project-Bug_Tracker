using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bug_Tracker.Models;
using Bug_Tracker.Util;
using Microsoft.AspNet.Identity;

namespace Bug_Tracker.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            return View(db.Tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int id)
        {
            Ticket tickets = TicketHelper.GetTicket(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string title, string content, int type)
        {
            if (ModelState.IsValid)
            {
                TicketHelper.Create(UserHelper.GetById(User.Identity.GetUserId()), title, content, TicketHelper.GetType(type), TicketHelper.GetPriority(1));
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int id)
        {
            Ticket tickets = TicketHelper.GetTicket(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, string title, string content, int type, int status, int priority)
        {
            return View(TicketHelper.Edit(Id, title, content, TicketHelper.GetType(type), TicketHelper.GetPriority(priority), TicketHelper.GetStatus(status)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
