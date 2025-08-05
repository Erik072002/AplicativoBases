using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Estado")]
    public class Estado
	{
        [Key]
        public int idEstado { get; set; }
        public string NombreDelEstado { get; set; }
        
    }
}
