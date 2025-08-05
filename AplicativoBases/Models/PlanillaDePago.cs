using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("PlanillaDePago")]
	public class PlanillaDePago
	{
		[Key]
		public int idPlanillaDePago { get; set; }
		public string periodo { get; set; }
		public DateTime fecha_pago { get; set; }
		public int idEstado { get; set; }
        public Estado Estado { get; set; }

    }
}