using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class LibroController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todos los libros
        /// </summary>
        /// <returns>JSON con todos los libros</returns>
        /// <response code="200">Devuelve la lista de libros</response>
        /// <response code="404">Si no se encuentra información</response>
        // GET: api/Libro
        public IEnumerable<Libro> Get()
        {
            return db.Libro; // o db.Libros si tu DbSet se llama así
        }

        /// <summary>
        /// Obtiene un libro por su ID
        /// </summary>
        /// <param name="id">ID del libro</param>
        /// <returns>JSON del libro</returns>
        /// <response code="200">Devuelve el libro encontrado</response>
        /// <response code="404">Si no se encuentra el libro</response>
        // GET: api/Libro/5
        public IHttpActionResult Get(int id)
        {
            Libro libro = db.Libro.Find(id); // o db.Libros
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        /// <summary>
        /// Crea un nuevo libro
        /// </summary>
        /// <param name="libro">Objeto libro a agregar</param>
        /// <returns>JSON del libro creado</returns>
        /// <response code="200">Devuelve el libro creado</response>
        /// <response code="400">Si el modelo es inválido</response>
        // POST: api/Libro
        public IHttpActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Libro.Add(libro); // o db.Libros
            db.SaveChanges();

            return Ok(libro);
        }

        /// <summary>
        /// Modifica un libro existente
        /// </summary>
        /// <param name="libroModificado">Libro con nuevos datos</param>
        /// <returns>JSON del libro actualizado</returns>
        /// <response code="200">Libro actualizado correctamente</response>
        /// <response code="404">Si el libro no existe</response>
        // PUT: api/Libro
        public IHttpActionResult Put(Libro libroModificado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!db.Libro.Any(l => l.IdLibro == libroModificado.IdLibro))
            {
                return NotFound();
            }

            db.Entry(libroModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(libroModificado);
        }

        /// <summary>
        /// Elimina un libro por ID
        /// </summary>
        /// <param name="id">ID del libro</param>
        /// <returns>Libro eliminado</returns>
        /// <response code="200">Libro eliminado correctamente</response>
        /// <response code="404">Si el libro no existe</response>
        // DELETE: api/Libro/5
        public IHttpActionResult Delete(int id)
        {
            Libro libro = db.Libro.Find(id); // o db.Libros
            if (libro == null)
            {
                return NotFound();
            }

            db.Libro.Remove(libro);
            db.SaveChanges();

            return Ok(libro);
        }

    }
}
