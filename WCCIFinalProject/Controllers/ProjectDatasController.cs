using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WCCIFinalProject.Models;

namespace WCCIFinalProject.Controllers
{
    public class ProjectDatasController : Controller
    {
        private ProjectDataEntities db = new ProjectDataEntities();

        // GET: ProjectDatas
        public ActionResult Index()
        {
            return View(db.ProjectDatas.ToList());
        }

        // GET: ProjectDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectData projectData = db.ProjectDatas.Find(id);
            if (projectData == null)
            {
                return HttpNotFound();
            }
            return View(projectData);
        }

        // GET: ProjectDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ProjectName,ProjectDescription,Language,ImageLink,GitHub,Collaborators")] ProjectData projectData)
        {
            if (ModelState.IsValid)
            {
                db.ProjectDatas.Add(projectData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectData);
        }

        // GET: ProjectDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectData projectData = db.ProjectDatas.Find(id);
            if (projectData == null)
            {
                return HttpNotFound();
            }
            return View(projectData);
        }

        // POST: ProjectDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,ProjectName,ProjectDescription,Language,ImageLink,GitHub,Collaborators")] ProjectData projectData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectData);
        }

        // GET: ProjectDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectData projectData = db.ProjectDatas.Find(id);
            if (projectData == null)
            {
                return HttpNotFound();
            }
            return View(projectData);
        }

        // POST: ProjectDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectData projectData = db.ProjectDatas.Find(id);
            db.ProjectDatas.Remove(projectData);
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
