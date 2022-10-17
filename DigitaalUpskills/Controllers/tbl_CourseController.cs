﻿using System;
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
    public class tbl_CourseController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_Course
        public ActionResult Index()
        {
            var tbl_Course = db.tbl_Course.Include(t => t.tbl_CourseCategory).Include(t => t.tbl_Instructor);
            return View(tbl_Course.ToList());
        }

        // GET: tbl_Course/Details/5
        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Course tbl_Course = db.tbl_Course.Find(id);
            if (tbl_Course == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Course);
        }

        // GET: tbl_Course/Create
        public ActionResult Create()
        {
            ViewBag.CourseCategory_Fid = new SelectList(db.tbl_CourseCategory, "CourseCategory_Id", "CourseCategory_Name");
            ViewBag.Instructor_Fid = new SelectList(db.tbl_Instructor, "Instructor_Id", "Instructor_Name");
            return View();
        }

        // POST: tbl_Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Course tbl_Course, HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/Content/Projectpic/" + pic.FileName);
            pic.SaveAs(fullpath);
            tbl_Course.Course_Image = ("~/Content/Projectpic/" + pic.FileName);

            if (ModelState.IsValid)
            {
                db.tbl_Course.Add(tbl_Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseCategory_Fid = new SelectList(db.tbl_CourseCategory, "CourseCategory_Id", "CourseCategory_Name", tbl_Course.CourseCategory_Fid);
            ViewBag.Instructor_Fid = new SelectList(db.tbl_Instructor, "Instructor_Id", "Instructor_Name", tbl_Course.Instructor_Fid);
            return View(tbl_Course);
        }

        // GET: tbl_Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Course tbl_Course = db.tbl_Course.Find(id);
            if (tbl_Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseCategory_Fid = new SelectList(db.tbl_CourseCategory, "CourseCategory_Id", "CourseCategory_Name", tbl_Course.CourseCategory_Fid);
            ViewBag.Instructor_Fid = new SelectList(db.tbl_Instructor, "Instructor_Id", "Instructor_Name", tbl_Course.Instructor_Fid);
            return View(tbl_Course);
        }

        // POST: tbl_Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Course tbl_Course, HttpPostedFileBase pic)
        {
            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    string fullpath = Server.MapPath("~/Content/Projectpic/" + pic.FileName);
                    pic.SaveAs(fullpath);
                    tbl_Course.Course_Image = ("~/Content/Projectpic/" + pic.FileName);
                }
                db.Entry(tbl_Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseCategory_Fid = new SelectList(db.tbl_CourseCategory, "CourseCategory_Id", "CourseCategory_Name", tbl_Course.CourseCategory_Fid);
            ViewBag.Instructor_Fid = new SelectList(db.tbl_Instructor, "Instructor_Id", "Instructor_Name", tbl_Course.Instructor_Fid);
            return View(tbl_Course);
        }

        // GET: tbl_Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Course tbl_Course = db.tbl_Course.Find(id);
            if (tbl_Course == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Course);
        }

        // POST: tbl_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Course tbl_Course = db.tbl_Course.Find(id);
            db.tbl_Course.Remove(tbl_Course);
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
