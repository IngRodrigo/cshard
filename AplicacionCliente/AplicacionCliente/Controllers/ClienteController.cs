using AplicacionCliente.Data;
using AplicacionCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionCliente.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost(Name ="Crear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                await _db.tablaClientes.AddAsync(cliente);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Crear));

            }
            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            var todos = await _db.tablaClientes.ToListAsync();

            return Json(new { data = todos });
        }
    }
}
