using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Libro_has_Prestamos")]
    public class Libro_has_Prestamos
	{
		public int idLibro { get; set; }
        [ForeignKey("idLibro")]
        public Libro Libro { get; set; }
        public int idPrestamos { get; set; }
        [ForeignKey("idPrestamos")]
        public Prestamos Prestamos { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int idEmpleadoEstadoLibro { get; set; }
        [ForeignKey("idEmpleadoEstadoLibro")]
        public Empleado EmpleadoEstadoLibro { get; set; }
        public Double TarifaPorDanios { get; set; }
        public int Cantidad { get; set; }

    }
}