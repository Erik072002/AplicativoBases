using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
    [Table("HistoricoDeAreas")]
    public class HistoricoDeAreas
	{
		public int idAreaDeTrabajo { get; set; }
		[ForeignKey("idAreaDeTrabajo")]
        public AreaDeTrabajo AreaDeTrabajo { get; set; }
        public int idEmpleado { get; set; }
        [ForeignKey("idEmpleado")]
        public Empleado Empleado { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

    }
}