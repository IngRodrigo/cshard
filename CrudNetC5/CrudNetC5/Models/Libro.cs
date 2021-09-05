using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetC5.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="El titulo es obligatorio")]
        [StringLength(50, ErrorMessage ="El {0} debe ser al menos {2} y máximo {1} caracteres")]
        [Display(Name ="Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="La descripción es requerida")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres")]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de lanzamiento")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage ="El nombre del autor es requerido")]
        public string Autor { get; set; }

        [Required(ErrorMessage ="El precio es requerido")]
        public int precio { get; set; }
    }
}
