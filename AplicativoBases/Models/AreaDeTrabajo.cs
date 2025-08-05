using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("AreaDeTrabajo")]
    public class AreaDeTrabajo
	{
		[Key]
		public int idAreaDeTrabajo { get; set; }
		public string Nombre { get; set; }

    }
}