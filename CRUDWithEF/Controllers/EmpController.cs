using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWithEF.Models;

namespace CRUDWithEF.Controllers
{
    public class EmpController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        //
        // GET: /Emp/

        public ActionResult Index()
        {
            return View(db.Emps.ToList());
        }

        //
        // GET: /Emp/Details/5

        public ActionResult Details(int id = 0)
        {
            Emp emp = db.Emps.Single(e => e.EmployeeID == id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //
        // GET: /Emp/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Emp/Create

        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.AddObject(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        //
        // GET: /Emp/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Emp emp = db.Emps.Single(e => e.EmployeeID == id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //
        // POST: /Emp/Edit/5

        [HttpPost]
        public ActionResult Edit(Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Attach(emp);
                db.ObjectStateManager.ChangeObjectState(emp, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        //
        // GET: /Emp/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Emp emp = db.Emps.Single(e => e.EmployeeID == id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //
        // POST: /Emp/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp emp = db.Emps.Single(e => e.EmployeeID == id);
            db.Emps.DeleteObject(emp);
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