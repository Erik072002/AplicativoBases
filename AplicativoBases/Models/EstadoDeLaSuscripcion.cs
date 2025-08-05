using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("EstadoDeLaSuscripcion")]
	public class EstadoDeLaSuscripcion
	{
		[Key]
		public int idEstadoDeLaSuscripcion { get; set; }
		public string Nombre { get; set; }

    }
}