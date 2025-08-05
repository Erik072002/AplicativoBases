using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Sucripcion")]
	public class Sucripcion
	{
		[Key]
		public int idSucripcion { get; set; }
		public int Cliente_idCliente { get; set; }
		[ForeignKey("Cliente_idCliente")]
        public Cliente Cliente { get; set; }
		public DateTime fecha_inicio { get; set; }
		public Double costo { get; set; }
		public int Metodo_De_Pago_idMetodo_De_Pago { get; set; }
        [ForeignKey("Metodo_De_Pago_idMetodo_De_Pago")]
        public Metodo_De_Pago Metodo_De_Pago { get; set; }
		public int EstadoDeLaSuscripcion_idEstadoDeLaSuscripcion { get; set; }
        [ForeignKey("EstadoDeLaSuscripcion_idEstadoDeLaSuscripcion")]
        public EstadoDeLaSuscripcion EstadoDeLaSuscripcion { get; set; }
		public int NivelDeSuscripcion_idNivelDeSuscripcion { get; set; }
        [ForeignKey("NivelDeSuscripcion_idNivelDeSuscripcion")]
        public NivelDeSuscripcion NivelDeSuscripcion { get; set; }

    }
}