using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCRUD.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Titulo")]
        [MaxLength(80)]
        public string titulo { get; set; }

        [Display(Name ="Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Display(Name ="Hora")]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }
    }
}
