using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomNotificationsWithSignalR.Models;

namespace CustomNotificationsWithSignalR.Controllers
{
    public class TestTablesController : Controller
    {
        private CustomNotificationDB db = new CustomNotificationDB();

        // GET: TestTables
        public ActionResult Index()
        {
            return View(db.TestTables.ToList());
        }

        // GET: TestTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTable testTable = db.TestTables.Find(id);
            if (testTable == null)
            {
                return HttpNotFound();
            }
            return View(testTable);
        }

        // GET: TestTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TestMessage")] TestTable testTable)
        {
            if (ModelState.IsValid)
            {
                db.TestTables.Add(testTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testTable);
        }

        // GET: TestTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTable testTable = db.TestTables.Find(id);
            if (testTable == null)
            {
                return HttpNotFound();
            }
            return View(testTable);
        }

        // POST: TestTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TestMessage")] TestTable testTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testTable);
        }

        // GET: TestTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTable testTable = db.TestTables.Find(id);
            if (testTable == null)
            {
                return HttpNotFound();
            }
            return View(testTable);
        }

        // POST: TestTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestTable testTable = db.TestTables.Find(id);
            db.TestTables.Remove(testTable);
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
