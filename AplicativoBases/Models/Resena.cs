using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Resena")]
    public class Resena
	{
		[Key]
		public int idResena { get; set; }
		public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
		public int idLibro { get; set; }
        [ForeignKey("idLibro")]
        public Libro Libro { get; set; }
        public int Calificacion { get; set; } 
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }


    }
}