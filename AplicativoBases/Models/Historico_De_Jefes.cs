using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
    [Table("Historico_De_Jefes")]
    public class Historico_De_Jefes
	{
		public int idEmpleadoJefe { get; set; }
        [ForeignKey(nameof(idEmpleadoJefe))]
        public Empleado EmpleadoJefe { get; set; }
		public int idEmpleadoJefe1 { get; set; }
        [ForeignKey(nameof(idEmpleadoJefe1))]
        public Empleado EmpleadoJefe1 { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}