using it_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace it_project.Controllers
{
    public class AdminController : Controller
    {
        private BurgerDBContext db = new BurgerDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            

            var burgers = db.Burgers;
            return View(burgers);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        { 

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Burger b)
        {
            try
            {
                // TODO: Add insert logic here
                db.Burgers.Add(b);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            //    foreach(Burger b in db.Burgers)
            //    {
            //        if(b.Id == id)
            //        {
            //            return View("Edit");
            //        }
            //    }
            //    return View("Edit");


            return View(db.Burgers.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,  Burger b)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {


            return View(db.Burgers.Where(x => x.Id == id).FirstOrDefault());

        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Burger b = db.Burgers.Where(x => x.Id == id).FirstOrDefault();
                db.Burgers.Remove(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
