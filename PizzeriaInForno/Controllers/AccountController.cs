using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PizzeriaInForno.Controllers
{
    public class AccountController : Controller
    {
        private readonly InFornoDbContext dbContext = new InFornoDbContext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Utenti utente)
        {
            if (ModelState.IsValid)
            {
                object value = dbContext.Utenti.Add(utente);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(utente);
        }
    }

    public class Utenti
    {
    }
}