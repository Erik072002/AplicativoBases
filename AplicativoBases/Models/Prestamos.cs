using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Prestamos")]
    public class Prestamos
	{
        [Key]
		public int idPrestamos { get; set; }
		public int? idSucripcion { get; set; }
        [ForeignKey("idSucripcion")]
        public Sucripcion Sucripcion { get; set; }

    }
}