using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Beneficios")]
    public class Beneficios
	{
		[Key]
        public int idBeneficios { get; set; }
		public string NombreDelBeneficio { get; set; }

    }
}