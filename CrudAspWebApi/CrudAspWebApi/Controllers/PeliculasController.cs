using CrudAspWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly AplicationDbContext _db;
        public PeliculasController(AplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> getPeliculas()
        {
            var peliculas =await _db.peliculas.OrderBy(peliculas => peliculas.nombre)
                .Include(peliculas=>peliculas.Categoria).ToListAsync();
            return Ok(peliculas);
        }
    }
}
