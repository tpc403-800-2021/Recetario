using Microsoft.AspNetCore.Mvc;
using Recetario.Data;
using Recetario.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Recetario.Controllers
{
    public class RecetaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RecetaController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET - INDEX
        [HttpGet]
        public IActionResult Index()
        {
            //_db.Recetas;
            //List<Receta> recetas = new List<Receta>();
            IEnumerable<Receta> obj = _db.Recetas;
            return View(obj);
        }

        //GET - CREAR
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Receta objeto)
        {
            if (ModelState.IsValid)
            {
                _db.Recetas.Add(objeto);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objeto);

        }

        //GET - EDITAR
        public IActionResult Editar(int? id)
        {
            // || = OR
            // && = AND
            if(id == null || id == 0 || id < 0)
            {
                return NotFound();
            }

            Receta recetaActual = _db.Recetas.Find(id);

            if (recetaActual == null)
            {
                return NotFound();
            }

            return View(recetaActual);
        }

        //POST - EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Receta objeto)
        {
            if (ModelState.IsValid)
            {
                _db.Recetas.Update(objeto);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objeto);

        }

        //GET - ELIMINAR
        public IActionResult Eliminar(int? id)
        {
            // || = OR
            // && = AND
            if (id == null || id == 0 || id < 0)
            {
                return NotFound();
            }

            Receta recetaActual = _db.Recetas.Find(id);

            if (recetaActual == null)
            {
                return NotFound();
            }

            return View(recetaActual);
        }

        //POST - ELIMINAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarAction(int? id)
        {
            if (id == null || id == 0 || id < 0)
            {
                return NotFound();
            }

            Receta recetaActual = _db.Recetas.Find(id);

            if (recetaActual == null)
            {
                return NotFound();
            }
            _db.Recetas.Remove(recetaActual);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
