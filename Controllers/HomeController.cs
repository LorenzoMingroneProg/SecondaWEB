using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mingrone.Lorenzo._5h.SecondaWeb.Models;

namespace Mingrone.Lorenzo._5h.SecondaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
          
        [HttpGet]
         public IActionResult Prenota()
        {
            return View();
        }

         [HttpGet]
         public IActionResult Elenco()
        {
            var db= new PrenotazioneContext();
            return View(db);
        }

          [HttpPost]
      public IActionResult Prenota(Prenotazione p)
        {
            //tipo - etichetta - operatore - valore - terminatore di istruzione 
            //var a=10;

            //tipo - etichetta - operatore - valore - terminatore di istruzione 
            PrenotazioneContext db = new PrenotazioneContext();
            db.Prenotazioni.Add(p);
            db.SaveChanges();
            
            return View("Grazie", db);
        }

        [HttpGet]
         public IActionResult Modifica(int Id)
        {
            var db = new PrenotazioneContext();
            Prenotazione prenotazione=db.Prenotazioni.Find(Id);
            return View("Modifica",prenotazione);
        
        }

         [HttpPost]
        
        public IActionResult Modifica(int id,Prenotazione nuovo)
        {
            var db = new PrenotazioneContext();
            var vecchio=db.Prenotazioni.Find(id);
            if(vecchio!=null)
            {
                vecchio.Nome=nuovo.Nome;
                vecchio.Email=nuovo.Email;
                db.Prenotazioni.Update(vecchio);
                db.SaveChanges();
                return View("Grazie",db);
            }
            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cancella( int id)
        {
            var db = new PrenotazioneContext();
            Prenotazione prenotazione=db.Prenotazioni.Find(id);
            db.Remove(prenotazione);
            db.SaveChanges();
            return View("Cancella",db);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

           public IActionResult Upload()
        {
            return View();
        } 
         
         [HttpPost]
         public IActionResult Upload(CreatePost post)
        {
            MemoryStream memStream=new MemoryStream();
            post.MyCSV.CopyTo(memStream);
            //mette a zero il puntatore dello StreamReader
            memStream.Seek(0,0);

            StreamReader fim=new StreamReader(memStream);
            if(!fim.EndOfStream)
            {
                //accedi al database
                var db=new PrenotazioneContext(); //oppure PrenotazioneContext db=new PrenotazioneContext(); 
                string riga = fim.ReadLine();
                while(!fim.EndOfStream)
                {
                    riga = fim.ReadLine();
                    string[] colonne = riga.Split(";");
                    Prenotazione p= new Prenotazione{Nome=colonne[0], Email=colonne[1], DataPrenotazione=Convert.ToDateTime(colonne[2])};
                    
                    db.Prenotazioni.Add(p);
                }                
                db.SaveChanges();
            
                return View("Grazie", db);                
            }         
            return View();
        }
    }
}
