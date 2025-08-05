using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
    [Table("VistaPersonaEmpleado")]
    public class VistaPersonaEmpleado
	{
        [Key]
        public int idPersonas { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int idEmpleado { get; set; }
        public int idBiblioteca { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Jornada { get; set; }
        public Double SueldoNeto { get; set; }
        public Double Salario { get; set; }
    }
}