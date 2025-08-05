using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

namespace ProyectoAeropuerto.Controllers
{
    public class Libro_has_PrestamosController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todos los registros de Libro_has_Prestamos
        /// </summary>
        /// <returns>JSON Libro_has_Prestamos</returns>
        /// <response code = "200">Devuelve la lista</response>
        /// <response code = "404">Si no se encuentra información</response>
        // GET: api/Libro_has_Prestamos
        public IEnumerable<Libro_has_Prestamos> Get()
        {
            return db.Libro_has_Prestamos;
        }

        /// <summary>
        /// Obtener un registro específico por idLibro e idPrestamos
        /// </summary>
        /// <param name="idLibro"></param>
        /// <param name="idPrestamos"></param>
        /// <returns>JSON Libro_has_Prestamos</returns>
        /// <response code = "200">Devuelve el valor encontrado</response>
        /// <response code = "404">Si no se encuentra</response>
        // GET: api/Libro_has_Prestamos
        [Route("api/Libro_has_Prestamos/{idLibro:int}/{idPrestamos:int}")]
        public IHttpActionResult Get(int idLibro, int idPrestamos)
        {
            Libro_has_Prestamos registro = db.Libro_has_Prestamos.Find(idLibro, idPrestamos);
            if (registro == null)
            {
                return NotFound();
            }
            return Ok(registro);
        }

        /// <summary>
        /// Crear un nuevo registro en Libro_has_Prestamos
        /// </summary>
        /// <param name="libroPrestamo"></param>
        /// <returns>JSON Libro_has_Prestamos</returns>
        /// <response code = "200">Devuelve el valor creado</response>
        /// <response code = "400">Si los datos son inválidos</response>
        // POST: api/Libro_has_Prestamos
        public IHttpActionResult Post(Libro_has_Prestamos libroPrestamo)
        {
            if (libroPrestamo == null)
            {
                return BadRequest("Datos inválidos.");
            }

            if (libroPrestamo.Libro != null)
            {
                Libro libro = db.Libro.Find(libroPrestamo.Libro.IdLibro);
                if (libro == null)
                {
                    return BadRequest("Libro no encontrado.");
                }
                libroPrestamo.Libro = libro;
            }

            if (libroPrestamo.Prestamos != null)
            {
                Prestamos prestamo = db.Prestamos.Find(libroPrestamo.Prestamos.idPrestamos);
                if (prestamo == null)
                {
                    return BadRequest("Préstamo no encontrado.");
                }
                libroPrestamo.Prestamos = prestamo;
            }

            if (libroPrestamo.EmpleadoEstadoLibro != null)
            {
                Empleado empleado = db.Empleado.Find(libroPrestamo.EmpleadoEstadoLibro.idEmpleado);
                if (empleado == null)
                {
                    return BadRequest("Empleado no encontrado.");
                }
                libroPrestamo.EmpleadoEstadoLibro = empleado;
            }

            db.Libro_has_Prestamos.Add(libroPrestamo);
            db.SaveChanges();

            return Ok(libroPrestamo);
        }

        /// <summary>
        /// Modificar un registro existente
        /// </summary>
        /// <param name="modificado"></param>
        /// <returns>JSON Libro_has_Prestamos</returns>
        /// <response code = "200">Devuelve el valor actualizado</response>
        /// <response code = "404">Si no se encuentra</response>
        // PUT: api/Libro_has_Prestamos
        public IHttpActionResult Put(Libro_has_Prestamos modificado)
        {
            if (modificado == null)
            {
                return BadRequest("Datos inválidos.");
            }

            db.Entry(modificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(modificado);
        }

        /// <summary>
        /// Eliminar un registro específico
        /// </summary>
        /// <param name="idLibro"></param>
        /// <param name="idPrestamos"></param>
        /// <returns>JSON Libro_has_Prestamos</returns>
        /// <response code = "200">Devuelve el valor eliminado</response>
        /// <response code = "404">Si no se encuentra</response>
        // DELETE: api/Libro_has_Prestamos
        [Route("api/Libro_has_Prestamos/{idLibro:int}/{idPrestamos:int}")]
        public IHttpActionResult Delete(int idLibro, int idPrestamos)
        {
            Libro_has_Prestamos registro = db.Libro_has_Prestamos.Find(idLibro, idPrestamos);
            if (registro == null)
            {
                return NotFound();
            }

            db.Libro_has_Prestamos.Remove(registro);
            db.SaveChanges();

            return Ok(registro);
        }
    }
}
