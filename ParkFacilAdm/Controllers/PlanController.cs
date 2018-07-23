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
    public class PlanController : Controller
    {
        public ParkFacilAdmEntities db = new ParkFacilAdmEntities();


        public PlanController()
        {
        }

        // GET: Plan
        public ActionResult Index()
        {
            return View(db.Plan.ToList());
        }


        // GET: Plan/Details/5
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

        // GET: Plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "NOMBRE_PLAN,DESCRIPCION_PLAN,UNIDAD_PLAN,PRECIO_PLAN,MAXIMO,MINUTOS_GRATIS")] Plan plan_in)
        {


            plan_in.CREADOR_PLAN = "1";

            db.Plan.Add(plan_in);
            var item = from a in db.Plan
                       select a;
            if (item.Count() == 0)
            {

                try
                {
                    db.SaveChanges();
                    TempData["ResultMessage"] = "Plan creado correctamente";
                    TempData["ResultType"] = "S";
                    return View(plan_in);
                }
                catch (Exception ex)
                {
                    TempData["ResultMessage"] = "Error en creción de Plan" + ex.Message;
                    TempData["ResultType"] = "E";
                    return View(plan_in);
                }
            }
            else
            {
                TempData["ResultMessage"] = "Color " + plan_in.NOMBRE_PLAN + " ya existe en el sistema";
                TempData["ResultType"] = "E";
                return View(plan_in);
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
        public ActionResult Edit([Bind(Include = "ID_PLAN,NOMBRE_PLAN,DESCRIPCION_PLAN,UNIDAD_PLAN,PRECIO_PLAN,MAXIMO,MINUTOS_GRATIS")] Plan plan_mod)
        {
            plan_mod.CREADOR_PLAN = "1";

            if (ModelState.IsValid)
            {
                db.Entry(plan_mod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan_mod);
        }

        // GET: Parking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            var item = from a in db.Plan
                       where a.ID_PLAN == id
                       select a;
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Parking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plan.Find(id);
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
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