using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicativoBases.Models
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Edicion { get; set; }
        public string ISBN { get; set; }

        public int idEstantes { get; set; } 
        [ForeignKey("idEstantes")]
        public Estantes Estantes { get; set; }

        public int idAutor { get; set; }
        [ForeignKey("idAutor")]
        public Autor Autor { get; set; }

        public string Editorial { get; set; }

        public int idTipoDeLibro { get; set; }
        [ForeignKey("idTipoDeLibro")]
        public TipoDeLibro TipoDeLibro { get; set; }

    }
}
