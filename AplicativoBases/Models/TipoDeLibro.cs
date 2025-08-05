using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
    [Table("TipoDeLibro")] 
    public class TipoDeLibro
	{
        [Key]
        public int IdTipoDeLibro { get; set; }
        public string Titulo { get; set; }
        
    }
}
