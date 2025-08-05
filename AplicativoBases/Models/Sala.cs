using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
    [Table("Sala")] 
    public class Sala
	{
		[Key]
        public int IdSala { get; set; }
		public string NombreDeLaSala { get; set; }
		public int IdBiblioteca { get; set; }
        
        [ForeignKey("IdBiblioteca")]
        public Biblioteca Biblioteca { get; set; }

    }
}