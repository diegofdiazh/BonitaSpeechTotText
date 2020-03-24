using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BonitaSpeechTotText.App_Tools;
using BonitaSpeechTotText.Models;
using BonitaSpeechTotText.Models.Data;

namespace BonitaSpeechTotText.Controllers
{
    public class ProcessController : BonitaController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Process
        public ActionResult IndexCamions()
        {
           
            return View(db.Camions.ToList());
        }

        // GET: Process/Details/5
        public ActionResult DetailsCamions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camion camion = db.Camions.Find(id);
            if (camion == null)
            {
                return HttpNotFound();
            }
            return View(camion);
        }

        // GET: Process/Create
        public ActionResult CreateCamions()
        {
            return View();
        }

        // POST: Process/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCamions([Bind(Include = "Id,Placas,NombreConductor,Liberar")] Camion camion)
        {

            if (ModelState.IsValid)
            {                
                db.Camions.Add(camion);
                db.SaveChanges();
                BonitaService.CrearCamion(camion);
                return RedirectToAction("IndexCamions");
            }

            return View(camion);
        }

        // GET: Process/Edit/5
        public ActionResult EditCamions (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camion camion = db.Camions.Find(id);
            if (camion == null)
            {
                return HttpNotFound();
            }
            return View(camion);
        }

        // POST: Process/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCamions([Bind(Include = "Id,Placas,NombreConductor,Liberar")] Camion camion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexCamions");
            }
            return View(camion);
        }

        // GET: Process/Delete/5
        public ActionResult DeleteCamions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camion camion = db.Camions.Find(id);
            if (camion == null)
            {
                return HttpNotFound();
            }
            return View(camion);
        }

        // POST: Process/Delete/5
        [HttpPost, ActionName("DeleteCamions")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCamions(int id)
        {
            Camion camion = db.Camions.Find(id);
            db.Camions.Remove(camion);
            db.SaveChanges();
            return RedirectToAction("IndexCamions");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Upload()
        {

            return View(db.Camions.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(int a=0)
        {

            return RedirectToAction("Index","Home");
        }
    }
}
