using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspWebApi.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string nombre { get; set; }
        
        [Required]
        public int CategoriaId { get; set; }


        public string Director { get; set; }

        //creamos la relacion con la tabla categorias
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        

    }
}
