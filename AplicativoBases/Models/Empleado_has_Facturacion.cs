using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Empleado_has_Facturacion")]
    public class Empleado_has_Facturacion
	{

		public int idEmpleado { get; set; }
        [ForeignKey("idEmpleado")]
        public Empleado Empleado { get; set; }
        public int idFacturacion { get; set; }
        [ForeignKey("idFacturacion")]
        public Facturacion Facturacion { get; set; }
        

    }
}