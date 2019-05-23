using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyTecniServer.Models;

namespace ProyTecniServer.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    return View(db.Categoria.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
             
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
           using (var db = new TecniserverEntities())
           {
                Categoria cat = db.Categoria.Find(id);
                return View(cat);
           }
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]//crea token que verifica que el form enviado pertenece aquí
        public ActionResult Create(Categoria c)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (var db = new TecniserverEntities())
                {
                    db.Categoria.Add(c);
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

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    //Categoria cat = db.Categoria.Where(a => a.Id_Categoria == id).FirstOrDefault();
                    Categoria cat = db.Categoria.Find(id);
                return View(cat);
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria c)
        {
            try
            {
                using (var db = new TecniserverEntities())
                {
                    Categoria cat = db.Categoria.Find(id);
                    cat.Nombre_Categoria = c.Nombre_Categoria;
                    cat.detalle = c.detalle;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al editar categoria", ex);
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new TecniserverEntities())
            {
                Categoria cat = db.Categoria.Find(id);
                db.Categoria.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
