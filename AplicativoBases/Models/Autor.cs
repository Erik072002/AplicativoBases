using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	[Table("Autor")]
    public class Autor
	{
        [Key]
        public int IdAutor { get; set; }
        public int IdPersonas { get; set; }
        [ForeignKey("IdPersonas")]
        public  Personas Personas { get; set; }

    }
}