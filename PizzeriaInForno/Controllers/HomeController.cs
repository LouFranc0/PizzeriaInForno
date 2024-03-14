using PizzeriaInForno.Models;

using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    public class HomeController : Controller
    {
        private readonly InFornoDbContext dbContext = new InFornoDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggiungiAlCarrello(int idArticolo, int quantita)
        {
            // Controlla se l'utente è autenticato
            if (User.Identity.IsAuthenticated)
            {
                // Ottieni l'ID utente corrente
                string username = User.Identity.Name;
                var utente = dbContext.Utenti.FirstOrDefault(u => u.Username == username);
                if (utente != null)
                {
                    // Cerca l'articolo nel database
                    var articolo = dbContext.Articoli.FirstOrDefault(a => a.ID == idArticolo);
                    if (articolo != null)
                    {
                        // Calcola il totale
                        decimal totale = articolo.Prezzo * quantita;

                        // Crea un nuovo ordine
                        var nuovoOrdine = new Ordini
                        {
                            IDUtente = utente.ID,
                            DataOrdine = DateTime.Now,
                            Stato = "In carrello",
                            Indirizzo = "Indirizzo di spedizione", // Imposta l'indirizzo di spedizione come necessario
                            Totale = totale // Imposta il totale calcolato
                        };

                        // Aggiungi l'ordine al database
                        dbContext.Ordini.Add(nuovoOrdine);
                        dbContext.SaveChanges();

                        // Ora puoi creare il record OrdiniArticoli
                        var nuovoOrdineArticolo = new OrdiniArticoli
                        {
                            IDOrdine = nuovoOrdine.ID,
                            IDArticolo = articolo.ID,
                            Quantita = quantita
                        };

                        // Aggiungi il record OrdiniArticoli al database
                        dbContext.OrdiniArticoli.Add(nuovoOrdineArticolo);
                        dbContext.SaveChanges();

                        // Reindirizza l'utente alla pagina degli articoli con un messaggio di successo
                        TempData["Message"] = "Articolo aggiunto al carrello con successo.";
                        return RedirectToAction("Index", "Articoli");
                    }
                }
            }

            // Se l'utente non è autenticato o ci sono problemi con l'utente o l'articolo, reindirizza all'accesso
            TempData["ErrorMessage"] = "Per aggiungere articoli al carrello, devi essere autenticato.";
            return RedirectToAction("Index", "Login");
        }


    }
}