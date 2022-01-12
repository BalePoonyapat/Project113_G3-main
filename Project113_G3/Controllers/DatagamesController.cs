using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Project113_G3.Models;

namespace Project113_G3.Controllers
{
    public class DatagamesController : Controller
    {
        private Datagame1 db = new Datagame1();

        // GET: Datagames
        public ActionResult Index()
        {
            return View(db.Datagame.ToList());
        }

        // GET: Datagames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datagame datagame = db.Datagame.Find(id);
            if (datagame == null)
            {
                return HttpNotFound();
            }
            return View(datagame);
        }

        // GET: Datagames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Datagames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameGame,TypeGame,Description_Game,url")] Datagame datagame)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    file.SaveAs(path);
                    datagame.url = fileName;

                }
                db.Datagame.Add(datagame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datagame);
        }

            // GET: Datagames/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datagame datagame = db.Datagame.Find(id);
            if (datagame == null)
            {
                return HttpNotFound();
            }
            return View(datagame);
        }

        // POST: Datagames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameGame,TypeGame,Description_Game,url")] Datagame datagame)
        {
            if (ModelState.IsValid)

            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    file.SaveAs(path);
                    datagame.url = fileName;

                }
                db.Entry(datagame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datagame);
        }

        // GET: Datagames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datagame datagame = db.Datagame.Find(id);
            if (datagame == null)
            {
                return HttpNotFound();
            }
            return View(datagame);
        }

        // POST: Datagames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datagame datagame = db.Datagame.Find(id);
            db.Datagame.Remove(datagame);
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
