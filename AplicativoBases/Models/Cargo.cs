using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Cargo")]
    public class Cargo
	{
        [Key]
        public int idCargo { get; set; }
        public string Nombre { get; set; }
        
    }
}