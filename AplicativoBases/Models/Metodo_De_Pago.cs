using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Metodo_De_Pago")]
    public class Metodo_De_Pago
	{
		[Key]
		public int idMetodo_De_Pago { get; set; }
		public string NombreDelMetodo { get; set; }

    }
}