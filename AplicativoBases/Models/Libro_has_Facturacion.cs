using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Libro_has_Facturacion")]
    public class Libro_has_Facturacion
	{
		public int Libro_idLibro { get; set; }
		[ForeignKey("Libro_idLibro")]
        public Libro Libro { get; set; }
        public int Facturacion_idFacturacion { get; set; }
        [ForeignKey("Facturacion_idFacturacion")]
        public Facturacion Facturacion { get; set; }
        public string CantidadDeLibros { get; set; }

    }
}