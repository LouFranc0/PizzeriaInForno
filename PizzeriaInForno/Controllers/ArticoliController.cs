using PizzeriaInForno.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    public class ArticoliController : Controller
    {
        private readonly InFornoDbContext dbContext = new InFornoDbContext();

        public ActionResult Index()
        {
            var articoli = dbContext.Articoli.ToList();
            return View(articoli);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Articoli articolo)
        {
            if (ModelState.IsValid)
            {
                dbContext.Articoli.Add(articolo);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articolo);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var articolo = dbContext.Articoli.Find(id);
            return View(articolo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Articoli articolo)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(articolo).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articolo);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var articolo = dbContext.Articoli.Find(id);
            return View(articolo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            var articolo = dbContext.Articoli.Find(id);
            dbContext.Articoli.Remove(articolo);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}