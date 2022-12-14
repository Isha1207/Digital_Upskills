using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitaalUpskills.Models;

namespace DigitaalUpskills.Controllers
{
    public class tbl_StudentController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_Student
        public ActionResult Index()
        {
            return View(db.tbl_Student.ToList());
        }

        // GET: tbl_Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // GET: tbl_Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_Id,Student_Name,Student_CNIC,Student_Gmail,Student_PhoneNo,Student_Address, Student Password")] tbl_Student tbl_Student)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Student.Add(tbl_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Student);
        }

        // GET: tbl_Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // POST: tbl_Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_Id,Student_Name,Student_CNIC,Student_Gmail,Student_PhoneNo,Student_Address,Student Password")] tbl_Student tbl_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Student);
        }

        // GET: tbl_Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // POST: tbl_Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            db.tbl_Student.Remove(tbl_Student);
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
