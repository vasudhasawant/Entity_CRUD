using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using entity_crud.Models;

namespace entity_crud.Controllers
{
    public class studentController : Controller
    {
        private StudentDBEntities db = new StudentDBEntities();

        // GET: student
        public ActionResult Index()
        {
            return View(db.student1.ToList());
        }

        // GET: student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student1 student1 = db.student1.Find(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // GET: student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,age,city")] student1 student1)
        {
            if (ModelState.IsValid)
            {
                db.student1.Add(student1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student1);
        }

        // GET: student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student1 student1 = db.student1.Find(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // POST: student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,age,city")] student1 student1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student1);
        }

        // GET: student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student1 student1 = db.student1.Find(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // POST: student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student1 student1 = db.student1.Find(id);
            db.student1.Remove(student1);
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
