using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevAplicativoBases.Models
{
	public class Cliente
	{
        [Key]
        public int IdCliente { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int IdPersonas { get; set; }

        
    }
}