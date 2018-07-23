using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkFacilAdm.Models;
using Microsoft.AspNet.Identity;

namespace ParkFacilAdm.Controllers
{
    public class ParkingController : Controller
    {
        public ParkFacilAdmEntities db = new ParkFacilAdmEntities();


        public ParkingController()
        {
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Parking.ToList());
        }


        // GET: Parking/Details/5
        /* public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Usuario usuario = db.Usuario.Find(id);
             if (usuario == null)
             {
                 return HttpNotFound();
             }
             return View(usuario);
         }
         */

        // GET: Parking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parking/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "NOMBRE_PARK,DIRECCION_PARK,COMUNA_PARK,REGION_PARK,CANTIDAD_PARK")] Parking park_in)
        {

            park_in.ID_EMPRESA = 1;
            park_in.CREADOR_PARK = "1";

            db.Parking.Add(park_in);
            var item = from a in db.Parking
                       where a.ID_EMPRESA == park_in.ID_EMPRESA
                       select a;
            if (item.Count() == 0)
            {

                try
                {
                    db.SaveChanges();
                    TempData["ResultMessage"] = "Estacionamiento creado correctamente";
                    TempData["ResultType"] = "S";
                    return View(park_in);
                }
                catch (Exception ex)
                {
                    TempData["ResultMessage"] = "Error en creción de parking" + ex.Message;
                    TempData["ResultType"] = "E";
                    return View(park_in);
                }
            }
            else
            {
                TempData["ResultMessage"] = "Color " + park_in.NOMBRE_PARK + " ya existe en el sistema";
                TempData["ResultType"] = "E";
                return View(park_in);
            }
        }

        // GET: Parking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parking.Find(id);
            var item = from a in db.Parking
                       where a.ID_PARKING == id
                       select a;
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PARKING,NOMBRE_PARK,DIRECCION_PARK,COMUNA_PARK,REGION_PARK,CANTIDAD_PARK")] Parking park_mod)
        {
            park_mod.ID_EMPRESA = 1;

            if (ModelState.IsValid)
            {
                db.Entry(park_mod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(park_mod);
        }

        // GET: Parking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parking.Find(id);
            var item = from a in db.Parking
                       where a.ID_PARKING == id
                       select a;
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: Parking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parking parking = db.Parking.Find(id);
            if (ModelState.IsValid)
            {
                db.Entry(parking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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