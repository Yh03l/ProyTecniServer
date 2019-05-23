using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyTecniServer.Models;

namespace ProyTecniServer.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new TecniserverEntities())
            {
                return View(db.Productos.ToList());
            }
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Productos cat = db.Productos.Find(id);
                return View(cat);
            }
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Productos datos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (var db = new TecniserverEntities())
                {
                    db.Productos.Add(datos);
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

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Productos cat = db.Productos.Find(id);
                return View(cat);
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Productos datos)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    Productos cat = db.Productos.Find(id);
                    cat.Nombre = datos.Nombre;
                    cat.Descripcion = datos.Descripcion;
                    cat.Precio_compra = datos.Precio_compra;
                    cat.Stock = datos.Stock;
                    cat.Id_categorias = datos.Id_categorias;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Productos cat = db.Productos.Find(id);
                return View(cat);
            }
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    Productos cat = db.Productos.Find(id);
                    db.Productos.Remove(cat);
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
