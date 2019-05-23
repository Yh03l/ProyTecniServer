using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyTecniServer.Models;

namespace ProyTecniServer.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (var db = new TecniserverEntities())
            {
                return View(db.Cliente.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Cliente cat = db.Cliente.Find(id);
                return View(cat);
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente datos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (var db = new TecniserverEntities())
                {
                    db.Cliente.Add(datos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al crear categoria", ex);
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Cliente cat = db.Cliente.Find(id);
                return View(cat);
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente datos)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    Cliente cat = db.Cliente.Find(id);
                    cat.Nombre_cliente = datos.Nombre_cliente;
                    cat.Apellido = datos.Apellido;
                    cat.Telefono = datos.Telefono;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Cliente cat = db.Cliente.Find(id);
                return View(cat);
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    Cliente cat = db.Cliente.Find(id);
                    db.Cliente.Remove(cat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
