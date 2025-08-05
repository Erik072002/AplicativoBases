using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicativoBases.Models
{
	public class Estantes
	{
        [Key]
        public int IdEstantes { get; set; }
        public string Nombre { get; set; }
        public int IdAreas { get; set; }
        [ForeignKey("IdAreas")]
        public Areas Areas { get; set; }
    }
}