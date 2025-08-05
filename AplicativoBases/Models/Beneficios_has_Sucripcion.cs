using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
    [Table("Beneficios_has_Sucripcion")]
    public class Beneficios_has_Sucripcion
	{
		public int idBeneficios { get; set; }
        [ForeignKey("idBeneficios")]
        public Beneficios Beneficios { get; set; }
        public int idSucripcion { get; set; }
        [ForeignKey("idSucripcion")]
        public Sucripcion Sucripcion { get; set; }

    }
}