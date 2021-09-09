using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionCliente.Models
{
    public class Clientes
    {
        [Key]
        [Display(Name ="Codigo")]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Nombres es requerido")]
        [MaxLength(80)]
        public string Nombres { get; set; }

        [Required(ErrorMessage ="El campo apellido es requerido")]
        [MaxLength(80)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(200)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(19)]
        public string Telefono { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}
