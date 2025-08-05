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
    public class AreasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Aeropuerto
        ///  </summary>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Aeropuerto
        public IEnumerable<Areas> Get()
        {
            return db.Areas;
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
            Areas areas = db.Areas.Find(id);
            if (areas == null)
            {
                NotFound();
            }
            return Ok(areas);
        }

        /// <summary>
        ///  Crear un Aeropuerto
        ///  </summary>
        ///  <param name="asiento"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Aeropuerto
        public IHttpActionResult Post(Areas areas)
        {
            db.Areas.Add(areas);
            db.SaveChanges();

            return Ok(areas);
        }

        /// <summary>
        ///  Modificar un Aeropuerto
        ///  </summary>
        ///  <param name="AeropuertoModificado"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Aeropuerto
        public IHttpActionResult Put(Areas AreaModificado)
        {
            int id = AreaModificado.IdAreas;
            db.Entry(AreaModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(AreaModificado);
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
            Areas areas = db.Areas.Find(id);
            db.Areas.Remove(areas);
            db.SaveChanges();

            return Ok(areas);
        }
    }
}
