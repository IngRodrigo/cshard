using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspWebApi.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name ="Codigo")]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre de la categorìa es obligatoria")]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}
