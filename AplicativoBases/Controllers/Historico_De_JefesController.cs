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
    public class Historico_De_JefesController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todos los Historico_De_Jefes
        /// </summary>
        /// <returns>JSON Historico_De_Jefes</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Historico_De_Jefes
        [HttpGet]
        [Route("api/HistoricoDeJefes")]
        public IEnumerable<Historico_De_Jefes> Get()
        {
            return db.Historico_De_Jefes;
        }

        /// <summary>
        /// Obtener la salida de Historico_De_Jefes por idEmpleadoJefe e idEmpleadoJefe1
        /// </summary>
        /// <param name="idEmpleadoJefe"></param>
        /// <param name="idEmpleadoJefe1"></param>
        /// <returns>JSON Historico_De_Jefes</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Historico_De_Jefes?idEmpleadoJefe=1&idEmpleadoJefe1=2
        public IHttpActionResult Get(int idEmpleadoJefe, int idEmpleadoJefe1)
        {
            Historico_De_Jefes historico = db.Historico_De_Jefes.Find(idEmpleadoJefe, idEmpleadoJefe1);
            if (historico == null)
            {
                return NotFound();
            }
            return Ok(historico);
        }

        /// <summary>
        /// Crear un Historico_De_Jefes
        /// </summary>
        /// <param name="historico"></param>
        /// <returns>JSON Historico_De_Jefes</returns>
        /// <response code="200">Devuelve el valor creado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Historico_De_Jefes
        public IHttpActionResult Post(Historico_De_Jefes historico)
        {
            if (historico.EmpleadoJefe != null)
            {
                Empleado empleadoJefeEncontrado = db.Empleado.Find(historico.EmpleadoJefe.idEmpleado);
                historico.EmpleadoJefe = empleadoJefeEncontrado;
            }

            if (historico.EmpleadoJefe1 != null)
            {
                Empleado empleadoJefe1Encontrado = db.Empleado.Find(historico.EmpleadoJefe1.idEmpleado);
                historico.EmpleadoJefe1 = empleadoJefe1Encontrado;
            }

            db.Historico_De_Jefes.Add(historico);
            db.SaveChanges();

            return Ok(historico);
        }

        /// <summary>
        /// Modificar un Historico_De_Jefes
        /// </summary>
        /// <param name="historicoModificado"></param>
        /// <returns>JSON Historico_De_Jefes</returns>
        /// <response code="200">Devuelve el valor modificado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Historico_De_Jefes
        public IHttpActionResult Put(Historico_De_Jefes historicoModificado)
        {
            db.Entry(historicoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(historicoModificado);
        }

        /// <summary>
        /// Eliminar un Historico_De_Jefes
        /// </summary>
        /// <param name="idEmpleadoJefe"></param>
        /// <param name="idEmpleadoJefe1"></param>
        /// <returns>JSON Historico_De_Jefes</returns>
        /// <response code="200">Devuelve el valor eliminado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Historico_De_Jefes?idEmpleadoJefe=1&idEmpleadoJefe1=2
        public IHttpActionResult Delete(int idEmpleadoJefe, int idEmpleadoJefe1)
        {
            Historico_De_Jefes historico = db.Historico_De_Jefes.Find(idEmpleadoJefe, idEmpleadoJefe1);
            if (historico == null)
            {
                return NotFound();
            }

            db.Historico_De_Jefes.Remove(historico);
            db.SaveChanges();

            return Ok(historico);
        }
    }
}
