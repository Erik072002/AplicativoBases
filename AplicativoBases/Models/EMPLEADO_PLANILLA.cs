using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("EMPLEADO_PLANILLA")]
    public class EMPLEADO_PLANILLA
	{
        public int idEmpleado { get; set; }
        [ForeignKey("idEmpleado")]
        public Empleado Empleado { get; set; }
        public int idPlanillaDePago { get; set; }
        [ForeignKey("idPlanillaDePago")]
        public PlanillaDePago PlanillaDePago { get; set; }
        public Double Sueldo { get; set; }
        public int HorasTrabajadas { get; set; }
        public Double Bonificaciones { get; set; }
        public Double deducciones { get; set; }

    }
}