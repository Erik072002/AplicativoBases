using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	public class Telefonos
	{
		[Key]
        public int IdTelefono { get; set; } 
		public string NumeroDeTelefonos { get; set; }
        public int IdPersonas { get; set; }
        [ForeignKey("IdPersonas")]
        public Personas Personas { get; set; }

    }
}