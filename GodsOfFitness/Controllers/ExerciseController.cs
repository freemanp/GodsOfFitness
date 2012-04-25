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
    public class ExerciseController : Controller
    {
        private GodsOfFitnessContext db = new GodsOfFitnessContext();

        //
        // GET: /Exercise/

        public ViewResult Index()
        {
            var exercises = db.Exercises.Include(e => e.User);
            return View(exercises.ToList());
        }

        //
        // GET: /Exercise/Details/5

        public ViewResult Details(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            return View(exercise);
        }

        //
        // GET: /Exercise/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email");
            return View();
        } 

        //
        // POST: /Exercise/Create

        [HttpPost]
        public ActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", exercise.UserId);
            return View(exercise);
        }
        
        //
        // GET: /Exercise/Edit/5
 
        public ActionResult Edit(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", exercise.UserId);
            return View(exercise);
        }

        //
        // POST: /Exercise/Edit/5

        [HttpPost]
        public ActionResult Edit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", exercise.UserId);
            return View(exercise);
        }

        //
        // GET: /Exercise/Delete/5
 
        public ActionResult Delete(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            return View(exercise);
        }

        //
        // POST: /Exercise/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
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