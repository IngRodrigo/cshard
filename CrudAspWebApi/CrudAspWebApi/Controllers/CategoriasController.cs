using CrudAspWebApi.Data;
using CrudAspWebApi.Models;
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
    public class CategoriasController : ControllerBase
    {
        private readonly AplicationDbContext _miBd;

        public CategoriasController(AplicationDbContext db)
        {
            _miBd = db;
        }

        //Lista categorias
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            //traemos la lista completa de las categorias ordenadas por nombre
            var lista = await _miBd.categorias.OrderBy(categorias => categorias.nombre).ToListAsync();
            //retornamos la lista
            return Ok(lista);
        }

        //Una sola categoria
        //cuando creamos una peticones con el mismo meetodo y que realizan operaciones similares
        //se debe agregar el parametro en una de ellas para diferenciarlas
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            //traemos la lista completa de las categorias ordenadas por nombre
            var objeto = await _miBd.categorias.FirstOrDefaultAsync(categorias => categorias.Id==id);
            if (objeto==null)
            {
                return NotFound();
            }
            //retornamos el objeto
            return Ok(objeto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]Categoria categoria)//From body, desde el cuerpo de la peticion y los parsea al modelo
        {
            if (categoria==null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            //si pasa las validaciones agregamos de forma asincrona a la bd
            await _miBd.AddAsync(categoria);
            //guardamos los cambios
            await _miBd.SaveChangesAsync();

            //retornamos ok
            return Ok();
        }
    }
}
