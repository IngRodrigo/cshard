using CrudNetC5.Data;
using CrudNetC5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetC5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AplicationDbContext _context;

        public LibrosController(AplicationDbContext context)
        {
            _context = context;
        }
        
        //Http get Index
        public IActionResult Index()
        {
            IEnumerable<Libro> ListaLibros = _context.Libro;
            return View(ListaLibros);
        }

        //Http get Create
        public IActionResult Create()
        {
            
            return View();
        }


        ////Http post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            ///Validando el modelo
            if (ModelState.IsValid)
            {
                //agrega el modelo a la instancia de la base de datos
                _context.Libro.Add(libro);
                //guarda los cambios
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha creado correctamente";

                return RedirectToAction("Index");//vuelve a redireccionar al index del controlador
            }
            return View();
        }

        //Http get Edit
        public IActionResult Edit(int? id)//puede ser nulo
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);
            if (libro==null)
            {
                return NotFound();
            }


            return View(libro);
        }
        ////Http post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            ///Validando el modelo
            if (ModelState.IsValid)
            {
                //agrega el modelo a la instancia de la base de datos
                _context.Libro.Update(libro);
                //guarda los cambios
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha actualizado correctamente";

                return RedirectToAction("Index");//vuelve a redireccionar al index del controlador
            }
            return View();
        }

        //Http get Delete
        public IActionResult Delete(int? id)//puede ser nulo
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }


            return View(libro);
        }
        ///Http post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {


            var libro = _context.Libro.Find(id);
            if (libro==null)
            {
                return NotFound();
            }
            _context.Libro.Remove(libro);
                //guarda los cambios
                _context.SaveChanges();

                TempData["mensaje"] = "El libro ha sido eliminado correctamente";

                return RedirectToAction("Index");//vuelve a redireccionar al index del controlador
       
        }
    }
}
