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
    public class UsuarioController : Controller
    {
        public ParkFacilAdmEntities db = new ParkFacilAdmEntities();
        

        public UsuarioController() {
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }


        // GET: Usuario/Details/5
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

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "NOMBRE_USUARIO,APELLIDO_USUARIO,MAIL_USUARIO,USUARIO,PASSWORD,RUT_USUARIO")] Usuario user_in)
        {

            user_in.ID_EMPRESA = 1;
            user_in.ID_TIPO_USUARIO = 2;
            user_in.FECHA_INGRESO_USUARIO = DateTime.Now.Date;
            user_in.FECHA_TERMINO_USUARIO = null;
            user_in.ESTADO_USUARIO = 1;
            user_in.CREADOR_USUARIO = "1";

            db.Usuario.Add(user_in);
                var item = from a in db.Usuario
                           where a.USUARIO == user_in.USUARIO || a.RUT_USUARIO == user_in.RUT_USUARIO
                           select a;
                if (item.Count() == 0)
                {

                    try
                    {
                        db.SaveChanges();
                        TempData["ResultMessage"] = "Operador creado correctamente";
                        TempData["ResultType"] = "S";
                        return View(user_in);
                    }
                    catch (Exception ex)
                    {
                        TempData["ResultMessage"] = "Error en creción de operador" + ex.Message;
                        TempData["ResultType"] = "E";
                        return View(user_in);
                    }
                }
                else
                {
                    TempData["ResultMessage"] = "Color " + user_in.USUARIO + " ya existe en el sistema";
                    TempData["ResultType"] = "E";
                    return View(user_in);
                }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            var item = from a in db.Usuario
                       where a.ID_USUARIO == id
                       select a;
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,NOMBRE_USUARIO,APELLIDO_USUARIO,MAIL_USUARIO,USUARIO,PASSWORD,RUT_USUARIO")] Usuario user_mod)
        {
            user_mod.ID_EMPRESA = 1;
            user_mod.ID_TIPO_USUARIO = 2;

            if (ModelState.IsValid)
            {
                db.Entry(user_mod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_mod);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            var item = from a in db.Usuario
                       where a.ID_USUARIO == id
                       select a;
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            usuario.ESTADO_USUARIO = 2;
            usuario.FECHA_TERMINO_USUARIO = DateTime.Now.Date;
            usuario.ID_USUARIO_OUT = "1";

            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
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
