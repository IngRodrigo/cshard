using CrudAspWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspWebApi.Data
{
    public class AplicationDbContext :DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options)
        {

        }

        public DbSet<Categoria> categorias { get; set; }

        public DbSet<Pelicula>peliculas { get; set; }
    }
}
