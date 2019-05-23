using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyTecniServer.Models;

namespace ProyTecniServer.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db = new TecniserverEntities())
            {
                return View(db.Proveedor.ToList());
            }
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Proveedor cat = db.Proveedor.Find(id);
                return View(cat);
            }
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proveedor p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (var db = new TecniserverEntities())
                {
                    db.Proveedor.Add(p);
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

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Proveedor cat = db.Proveedor.Find(id);
                return View(cat);
            }
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Proveedor p)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    Proveedor cat = db.Proveedor.Find(id);
                    cat.Nombre = p.Nombre;
                    cat.Apellido = p.Apellido;
                    cat.Direccion = p.Direccion;
                    cat.Telefono_Proveedor = p.Telefono_Proveedor;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Proveedor cat = db.Proveedor.Find(id);
                return View(cat);
            }
        }

        // POST: Proveedor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Proveedor p)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    Proveedor cat = db.Proveedor.Find(id);
                    db.Proveedor.Remove(cat);
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
