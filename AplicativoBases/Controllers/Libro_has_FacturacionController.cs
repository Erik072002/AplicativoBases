using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

namespace ProyectoAeropuerto.Controllers
{
    public class Libro_has_FacturacionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todos los registros de Libro_has_Facturacion
        /// </summary>
        /// <returns>JSON Libro_has_Facturacion</returns>
        public IEnumerable<Libro_has_Facturacion> Get()
        {
            return db.Libro_has_Facturacion;
        }

        /// <summary>
        /// Obtener un registro específico por Libro_idLibro y Facturacion_idFacturacion
        /// </summary>
        /// <param name="libro_idLibro"></param>
        /// <param name="facturacion_idFacturacion"></param>
        /// <returns>JSON Libro_has_Facturacion</returns>
        [Route("api/Libro_has_Facturacion/{libro_idLibro:int}/{facturacion_idFacturacion:int}")]
        public IHttpActionResult Get(int libro_idLibro, int facturacion_idFacturacion)
        {
            Libro_has_Facturacion registro = db.Libro_has_Facturacion.Find(libro_idLibro, facturacion_idFacturacion);
            if (registro == null)
            {
                return NotFound();
            }
            return Ok(registro);
        }

        /// <summary>
        /// Crear un nuevo registro en Libro_has_Facturacion
        /// </summary>
        /// <param name="libroFacturacion"></param>
        /// <returns>JSON Libro_has_Facturacion</returns>
        public IHttpActionResult Post(Libro_has_Facturacion libroFacturacion)
        {
            if (libroFacturacion == null)
            {
                return BadRequest("Datos inválidos.");
            }

            if (libroFacturacion.Libro != null)
            {
                Libro libro = db.Libro.Find(libroFacturacion.Libro.IdLibro);
                if (libro == null)
                {
                    return BadRequest("Libro no encontrado.");
                }
                libroFacturacion.Libro = libro;
            }

            if (libroFacturacion.Facturacion != null)
            {
                Facturacion facturacion = db.Facturacion.Find(libroFacturacion.Facturacion.idFacturacion);
                if (facturacion == null)
                {
                    return BadRequest("Facturación no encontrada.");
                }
                libroFacturacion.Facturacion = facturacion;
            }

            db.Libro_has_Facturacion.Add(libroFacturacion);
            db.SaveChanges();

            return Ok(libroFacturacion);
        }

        /// <summary>
        /// Modificar un registro existente
        /// </summary>
        /// <param name="modificado"></param>
        /// <returns>JSON Libro_has_Facturacion</returns>
        public IHttpActionResult Put(Libro_has_Facturacion modificado)
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
        /// <param name="libro_idLibro"></param>
        /// <param name="facturacion_idFacturacion"></param>
        /// <returns>JSON Libro_has_Facturacion</returns>
        [Route("api/Libro_has_Facturacion/{libro_idLibro:int}/{facturacion_idFacturacion:int}")]
        public IHttpActionResult Delete(int libro_idLibro, int facturacion_idFacturacion)
        {
            Libro_has_Facturacion registro = db.Libro_has_Facturacion.Find(libro_idLibro, facturacion_idFacturacion);
            if (registro == null)
            {
                return NotFound();
            }

            db.Libro_has_Facturacion.Remove(registro);
            db.SaveChanges();

            return Ok(registro);
        }
    }
}
