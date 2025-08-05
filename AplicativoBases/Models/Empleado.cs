using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        public int idEmpleado { get; set; }

        public string Jornada { get; set; }

        public int idPersonas { get; set; }

        [ForeignKey("idPersonas")]
        public Personas Personas { get; set; }

        public int idBiblioteca { get; set; }

        [ForeignKey("idBiblioteca")]
        public Biblioteca Biblioteca { get; set; }

        public double SueldoNeto { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
