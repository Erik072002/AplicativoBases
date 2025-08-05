using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	public class Areas
	{
        [Key]
        public int IdAreas { get; set; }
        public string Nombre { get; set; }
        public int IdSala { get; set; }
        [ForeignKey("IdSala")]
        public Sala Sala { get; set; }
    }
}