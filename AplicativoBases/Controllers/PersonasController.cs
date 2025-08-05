using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAeropuerto.Controllers
{
    public class PersonasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Aeropuerto
        ///  </summary>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Aeropuerto
        public IEnumerable<Personas> Get()
        {
            return db.Personas;
        }

        /// <summary>
        ///  Obtener la salida de Aeropuerto por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Aeropuerto
        public IHttpActionResult Get(int id)
        {
            Personas aeropuerto = db.Personas.Find(id);
            if (aeropuerto == null)
            {
                NotFound();
            }
            return Ok(aeropuerto);
        }

        /// <summary>
        ///  Crear un Aeropuerto
        ///  </summary>
        ///  <param name="asiento"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Aeropuerto
        public IHttpActionResult Post(Personas aeropuerto)
        {
            db.Personas.Add(aeropuerto);
            db.SaveChanges();

            return Ok(aeropuerto);
        }

        /// <summary>
        ///  Modificar un Aeropuerto
        ///  </summary>
        ///  <param name="AeropuertoModificado"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Aeropuerto
        public IHttpActionResult Put(Personas AeropuertoModificado)
        {
            int id = AeropuertoModificado.idPersonas;
            db.Entry(AeropuertoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(AeropuertoModificado);
        }

        /// <summary>
        ///  Eliminar un Aeropuerto
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Aeropuerto
        public IHttpActionResult Delete(int id)
        {
            Personas aeropuerto = db.Personas.Find(id);
            db.Personas.Remove(aeropuerto);
            db.SaveChanges();

            return Ok(aeropuerto);
        }
    }
}
