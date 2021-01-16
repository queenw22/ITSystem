using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketFinalSys.DAL;
using TicketFinalSys.Models;


namespace TicketFinalSys.Controllers
{
    public class TicketController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: Ticket
        //Technician Index page controller (displays all tickets opened and closed)
        public ActionResult Index()
        {
            return View(db.Tickets.ToList());
        }

        //open tickets controller 
        public ActionResult Open(string sortOrder)
        {
            //order by tech assigned and date 
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "tech_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date " ? "date_desc" : "Date";

            //assign all open tickets to the variable tickets 
            var tickets = db.Tickets.Where(t => t.Status == "open");

            //switch case for sorting the data 
            switch (sortOrder)
            {
                case "tech_desc":
                    tickets = tickets.OrderByDescending(t => t.TechAssigned);
                    break;

                case "Date":
                    tickets = tickets.OrderBy(t => t.RequestDate);
                    break;

                case "date_desc":
                    tickets = tickets.OrderByDescending(t => t.RequestDate);
                    break;
                default:
                    tickets = tickets.OrderBy(t => t.TechAssigned);
                    break;
            }

            return View(tickets.ToList());
        }

        //ticket confirmation view controller 
        public ActionResult Confirmation()
        {
            return View();
        }


        // GET: Ticket/Edit/5
        //Assign Tech view contoller with id as parameter to select current ticket 
        public ActionResult AssignTech(int? id)
        {
            //if id is null
            if (id == null)
            {
                //return bad request 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //otherwise assign the current ticket to the variable ticket 
            Ticket ticket = db.Tickets.Find(id);

            //if ticket is null 
            if (ticket == null)
            {
                //return not found error 
                return HttpNotFound();
            }
            
            //display the ticket in the view 
            return View(ticket);
        }

        //update database after info in AssignTech View is entered
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignTech([Bind(Include = "ID,FirstName,LastName," +
            "RequestDate,RequestDesc,TechAssigned,CompletionDate,Note,Status")] Ticket ticket)
        {
            //if model is valid 
            if (ModelState.IsValid)
            {

                //get the updated data 
                db.Entry(ticket).State = EntityState.Modified;

                //save the changed made in the view to the database 
                db.SaveChanges();

                //redirect to the Open Ticket view
                return RedirectToAction("Open");
            }
            return View(ticket);
        }



        // GET: Ticket/Details/5
        //Details view contoller with id as parameter to select current ticket 
        public ActionResult Details(int? id)
        {
            //if id is null
            if (id == null)
            {
                //return bad request 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //otherwise assign the current ticket to the variable ticket 
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                //return not found errror
                return HttpNotFound();
            }
            //display ticket in view 
            return View(ticket);
        }

        // GET: Ticket/Create
        //create view controller .
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        //update database after info in Ticket Request View is entered
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,RequestDate,RequestDesc,TechAssigned,CompletionDate,Note,Status")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Confirmation");
            }

            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            //if id is null
            if (id == null)
            {
                //return bad request 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //otherwise assign the current ticket to the variable ticket 
            Ticket ticket = db.Tickets.Find(id);

            //if ticket is null
            if (ticket == null)
            {
                //return not found error
                return HttpNotFound();
            }
            //display ticket in the view
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        //update database after info in edit view is modified 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,RequestDate,RequestDesc,TechAssigned,CompletionDate,Note,Status")] Ticket ticket)
        {
            //if model is valid 
            if (ModelState.IsValid)
            {
 
                //get database updates 
                db.Entry(ticket).State = EntityState.Modified;
                //save changes 
                db.SaveChanges();
                //redirect to index page 
                return RedirectToAction("Index");
            }

            //display ticket in view
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            //if id is null
            if (id == null)
            {
                //return bad request 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //otherwise assign the current ticket to the variable ticket 
            Ticket ticket = db.Tickets.Find(id);

            //if ticket is null
            if (ticket == null)
            {
                //return not found error
                return HttpNotFound();
            }
            //display in view
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        //update database after ticket is deleted 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
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
