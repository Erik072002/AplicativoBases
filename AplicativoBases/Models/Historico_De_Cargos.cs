using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Historico_De_Cargos")]
    public class Historico_De_Cargos
	{
		public int idCargo { get; set; }
		[ForeignKey("idCargo")]
        public Cargo Cargo { get; set; }
        public int idEmpleado { get; set; }
        [ForeignKey("idEmpleado")]
        public Empleado Empleado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}