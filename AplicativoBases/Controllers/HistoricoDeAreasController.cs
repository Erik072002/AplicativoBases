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
    public class HistoricoDeAreasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/HistoricoDeAreas
        [HttpGet]
        [Route("api/HistoricoDeAreas")]
        public IEnumerable<HistoricoDeAreas> Get()
        {
            return db.HistoricoDeAreas;
        }

        // GET: api/HistoricoDeAreas/{idAreaDeTrabajo}/{idEmpleado}
        [HttpGet]
        [Route("api/HistoricoDeAreas/{idAreaDeTrabajo:int}/{idEmpleado:int}")]
        public IHttpActionResult Get(int idAreaDeTrabajo, int idEmpleado)
        {
            HistoricoDeAreas historico = db.HistoricoDeAreas.Find(idAreaDeTrabajo, idEmpleado);
            if (historico == null)
            {
                return NotFound();
            }
            return Ok(historico);
        }

        /// <summary>
        ///  Crear un HistoricoDeAreas
        ///  </summary>
        ///  <param name="historico"></param>
        /// <returns>JSON HistoricoDeAreas</returns>
        /// <response code = "200"> Devuelve el valor creado</response>
        /// <response code = "404"> Si el valor no es encontrado</response>
        // POST: api/HistoricoDeAreas
        public IHttpActionResult Post(HistoricoDeAreas historico)
        {
            if (historico.AreaDeTrabajo != null)
            {
                AreaDeTrabajo areaEncontrada = db.AreasDeTrabajo.Find(historico.AreaDeTrabajo.idAreaDeTrabajo);
                historico.AreaDeTrabajo = areaEncontrada;
            }

            if (historico.Empleado != null)
            {
                Empleado empleadoEncontrado = db.Empleado.Find(historico.Empleado.idEmpleado);
                historico.Empleado = empleadoEncontrado;
            }

            db.HistoricoDeAreas.Add(historico);
            db.SaveChanges();

            return Ok(historico);
        }

        /// <summary>
        ///  Modificar un HistoricoDeAreas
        ///  </summary>
        ///  <param name="historicoModificado"></param>
        /// <returns>JSON HistoricoDeAreas</returns>
        /// <response code = "200"> Devuelve el valor modificado</response>
        /// <response code = "404"> Si el valor no es encontrado</response>
        // PUT: api/HistoricoDeAreas
        public IHttpActionResult Put(HistoricoDeAreas historicoModificado)
        {
            db.Entry(historicoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(historicoModificado);
        }

        /// <summary>
        ///  Eliminar un HistoricoDeAreas
        ///  </summary>
        ///  <param name="idAreaDeTrabajo"></param>
        ///  <param name="idEmpleado"></param>
        /// <returns>JSON HistoricoDeAreas</returns>
        /// <response code = "200"> Devuelve el valor eliminado</response>
        /// <response code = "404"> Si el valor no es encontrado</response>
        // DELETE: api/HistoricoDeAreas?idAreaDeTrabajo=1&idEmpleado=2
        public IHttpActionResult Delete(int idAreaDeTrabajo, int idEmpleado)
        {
            HistoricoDeAreas historico = db.HistoricoDeAreas.Find(idAreaDeTrabajo, idEmpleado);
            if (historico == null)
            {
                return NotFound();
            }

            db.HistoricoDeAreas.Remove(historico);
            db.SaveChanges();

            return Ok(historico);
        }
    }
}
