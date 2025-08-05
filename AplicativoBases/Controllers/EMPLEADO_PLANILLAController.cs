using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class EMPLEADO_PLANILLAController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todos los registros de EMPLEADO_PLANILLA
        /// </summary>
        /// <returns>JSON EMPLEADO_PLANILLA</returns>
        /// <response code="200">Devuelve los valores encontrados</response>
        /// <response code="404">Si no se encuentran valores</response>
        // GET: api/EMPLEADO_PLANILLA
        [HttpGet]
        [Route("api/EMPLEADO_PLANILLA")]
        public IEnumerable<EMPLEADO_PLANILLA> Get()
        {
            return db.EMPLEADO_PLANILLA;
        }

        /// <summary>
        /// Obtiene un registro de EMPLEADO_PLANILLA por ID de empleado y planilla
        /// </summary>
        /// <param name="idEmpleado"></param>
        /// <param name="idPlanillaDePago"></param>
        /// <returns>JSON EMPLEADO_PLANILLA</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si no se encuentra el valor</response>
        // GET: api/EMPLEADO_PLANILLA?idEmpleado=1&idPlanillaDePago=1
        [HttpGet]
        [Route("api/EMPLEADO_PLANILLA/{idEmpleado:int}/{idPlanillaDePago:int}")]
        public IHttpActionResult Get(int idEmpleado, int idPlanillaDePago)
        {
            var registro = db.EMPLEADO_PLANILLA.Find(idEmpleado, idPlanillaDePago);
            if (registro == null)
                return NotFound();

            return Ok(registro);
        }

        /// <summary>
        /// Crea un nuevo registro de EMPLEADO_PLANILLA
        /// </summary>
        /// <param name="registro"></param>
        /// <returns>JSON EMPLEADO_PLANILLA</returns>
        /// <response code="200">Devuelve el valor creado</response>
        /// <response code="400">Si el modelo es inválido</response>
        // POST: api/EMPLEADO_PLANILLA
        public IHttpActionResult Post(EMPLEADO_PLANILLA registro)
        {
            if (registro.Empleado != null)
            {
                registro.Empleado = db.Empleado.Find(registro.Empleado.idEmpleado);
            }
            if (registro.PlanillaDePago != null)
            {
                registro.PlanillaDePago = db.PlanillaDePago.Find(registro.PlanillaDePago.idPlanillaDePago);
            }

            db.EMPLEADO_PLANILLA.Add(registro);
            db.SaveChanges();

            return Ok(registro);
        }

        /// <summary>
        /// Modifica un registro de EMPLEADO_PLANILLA
        /// </summary>
        /// <param name="registroModificado"></param>
        /// <returns>JSON EMPLEADO_PLANILLA</returns>
        /// <response code="200">Devuelve el valor modificado</response>
        /// <response code="400">Si el modelo es inválido</response>
        // PUT: api/EMPLEADO_PLANILLA
        public IHttpActionResult Put(EMPLEADO_PLANILLA registroModificado)
        {
            db.Entry(registroModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(registroModificado);
        }

        /// <summary>
        /// Elimina un registro de EMPLEADO_PLANILLA
        /// </summary>
        /// <param name="idEmpleado"></param>
        /// <param name="idPlanillaDePago"></param>
        /// <returns>JSON EMPLEADO_PLANILLA</returns>
        /// <response code="200">Devuelve el valor eliminado</response>
        /// <response code="404">Si no se encuentra el valor</response>
        // DELETE: api/EMPLEADO_PLANILLA?idEmpleado=1&idPlanillaDePago=1
        public IHttpActionResult Delete(int idEmpleado, int idPlanillaDePago)
        {
            var registro = db.EMPLEADO_PLANILLA.Find(idEmpleado, idPlanillaDePago);
            if (registro == null)
                return NotFound();

            db.EMPLEADO_PLANILLA.Remove(registro);
            db.SaveChanges();

            return Ok(registro);
        }
    }
}
