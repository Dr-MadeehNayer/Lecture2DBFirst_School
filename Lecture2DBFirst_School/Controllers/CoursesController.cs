using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lecture2DBFirst_School.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System.IO;
using System.ComponentModel;

namespace Lecture2DBFirst_School.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private Lecture2SchoolEntities db = new Lecture2SchoolEntities();

        // GET: Courses
        //public ActionResult Index()
        //{
        //    return View(db.Courses.ToList());
        //}

        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {

            var courses = (from m in db.Courses
                           select m);

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.Title.Contains(searchString));
            }

            if (User.IsInRole(RoleName.Manager) || User.IsInRole(RoleName.Admin))
            {
                return View(courses.ToList());
            }
            else
            {
                return View("ReadOnlyIndex",courses.ToList());
            }
        }

        [Authorize(Roles=RoleName.Admin)]
        public ActionResult IndexMultipleRecordsDelete()
        {
            return View(db.Courses.ToList());
        }

        [HttpPost]
        public ActionResult IndexMultipleRecordsDelete(FormCollection formCollection)
        {
            try
            {
                string[] ids = formCollection["ID"].Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    var courses = this.db.Courses.Find(int.Parse(id));
                    this.db.Courses.Remove(courses);
                    this.db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction("IndexMultipleRecordsDelete");
        }


        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
           // var currentUser = User.Identity.GetUserId();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = db.Courses.Where(c=>c.CourseId==id).Include(e => e.AspNetUser).FirstOrDefault();
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        
        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.InstructorId = new SelectList(db.v_getTrainers, "Id", "UserName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Title,Credits,InstructorId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteConfirmedJSON(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DrawChart()
        {
            return View(db.Courses.ToList());

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
