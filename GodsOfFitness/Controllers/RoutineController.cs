using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GodsOfFitness.Models;

namespace GodsOfFitness.Controllers
{ 
    public class RoutineController : Controller
    {
        private GodsOfFitnessContext db = new GodsOfFitnessContext();

        //
        // GET: /Routine/

        public ViewResult Index()
        {
            var routines = db.Routines.Include(r => r.User).Include(r => r.Type);
            return View(routines.ToList());
        }

        //
        // GET: /Routine/Details/5

        public ViewResult Details(int id)
        {
            Routine routine = db.Routines.Find(id);
            return View(routine);
        }

        //
        // GET: /Routine/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email");
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name");
            return View();
        } 

        //
        // POST: /Routine/Create

        [HttpPost]
        public ActionResult Create(Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Routines.Add(routine);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", routine.UserId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", routine.TypeId);
            return View(routine);
        }
        
        //
        // GET: /Routine/Edit/5
 
        public ActionResult Edit(int id)
        {
            Routine routine = db.Routines.Find(id);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", routine.UserId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", routine.TypeId);
            return View(routine);
        }

        //
        // POST: /Routine/Edit/5

        [HttpPost]
        public ActionResult Edit(Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", routine.UserId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", routine.TypeId);
            return View(routine);
        }

        //
        // GET: /Routine/Delete/5
 
        public ActionResult Delete(int id)
        {
            Routine routine = db.Routines.Find(id);
            return View(routine);
        }

        //
        // POST: /Routine/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Routine routine = db.Routines.Find(id);
            db.Routines.Remove(routine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}