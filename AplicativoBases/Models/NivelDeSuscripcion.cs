using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("NivelDeSuscripcion")]
	public class NivelDeSuscripcion
	{
		[Key]
		public int idNivelDeSuscripcion {  get; set; }
		public string Nombre { get; set; }


    }
}