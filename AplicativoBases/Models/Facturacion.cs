using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Facturacion")]
    public class Facturacion
	{
		[Key]
		public int idFacturacion { get; set; }
	    public Double MontoTotal { get; set; }
		public int Cliente_idCliente { get; set; }
        [ForeignKey("Cliente_idCliente")]
        public Cliente Cliente { get; set; }
		public int Metodo_De_Pago_idMetodo_De_Pago { get; set; }
        [ForeignKey("Metodo_De_Pago_idMetodo_De_Pago")]
        public Metodo_De_Pago Metodo_De_Pago { get; set; }

    }
}