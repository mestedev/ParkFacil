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
    public class ClienteController : Controller
    {
        public ParkFacilAdmEntities db = new ParkFacilAdmEntities();

        public ClienteController (){
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        // GET: Cliente/Details/5
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

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "NOMBRE_CLIENTE,APELLIDO_CLIENTE,RUT_CLIENTE,MAIL_CLIENTE,TELEFONO_CLIENTE,PATENTE_CLIENTE,VIGENCIA_CLIENTE,FECHA_INGRESO_CLIENTE,FECHA_TERMINO_CLIENTE")] Cliente cliente_in)
        {
            cliente_in.CREADOR_CLIENTE = "1";
            cliente_in.ID_ESTADO_CLIENTE = 1;
            cliente_in.ID_TIPO_CLIENTE = 1;
            cliente_in.VIGENCIA_CLIENTE = 1;
            cliente_in.FECHA_INGRESO_CLIENTE = DateTime.Now.Date;
            cliente_in.FECHA_TERMINO_CLIENTE = null;

            db.Cliente.Add(cliente_in);
            var item = from a in db.Cliente
                       select a;
            if (item.Count() == 0)
            {

                try
                {
                    db.SaveChanges();
                    TempData["ResultMessage"] = "Cliente creado correctamente";
                    TempData["ResultType"] = "S";
                    return View(cliente_in);
                }
                catch (Exception ex)
                {
                    TempData["ResultMessage"] = "Error en creción de Cliente" + ex.Message;
                    TempData["ResultType"] = "E";
                    return View(cliente_in);
                }
            }
            else
            {
                TempData["ResultMessage"] = "Color " + cliente_in.RUT_CLIENTE + " ya existe en el sistema";
                TempData["ResultType"] = "E";
                return View(cliente_in);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            var item = from a in db.Cliente
                       where a.ID_CLIENTE == id
                       select a;
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLIENTE,NOMBRE_CLIENTE,APELLIDO_CLIENTE,RUT_CLIENTE,MAIL_CLIENTE,TELEFONO_CLIENTE,PATENTE_CLIENTE,VIGENCIA_CLIENTE,FECHA_INGRESO_CLIENTE,FECHA_TERMINO_CLIENTE")] Cliente cliente_mod)
        {
            cliente_mod.CREADOR_CLIENTE= "1";
            cliente_mod.ID_ESTADO_CLIENTE = 1;
            cliente_mod.ID_TIPO_CLIENTE = 1;
            cliente_mod.VIGENCIA_CLIENTE = 1;

            if (ModelState.IsValid)
            {
                db.Entry(cliente_mod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente_mod);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            var item = from a in db.Cliente
                       where a.ID_CLIENTE == id
                       select a;
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Cliente cliente = db.Cliente.Find(id);

            cliente.FECHA_TERMINO_CLIENTE = DateTime.Now.Date;
            cliente.ID_ESTADO_CLIENTE = 2;
            cliente.VIGENCIA_CLIENTE = 2;

            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
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