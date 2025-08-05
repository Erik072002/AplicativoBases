using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class PlanillaDePagoController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todas las PlanillaDePago
        /// </summary>
        /// <returns>JSON PlanillaDePago</returns>
        /// <response code="200">Devuelve los valores encontrados</response>
        /// <response code="404">Si no se encuentran valores</response>
        // GET: api/PlanillaDePago
        [HttpGet]
        public IEnumerable<PlanillaDePago> Get()
        {
            return db.PlanillaDePago;
        }

        /// <summary>
        /// Obtiene una PlanillaDePago por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON PlanillaDePago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si no se encuentra el valor</response>
        // GET: api/PlanillaDePago/5
        public IHttpActionResult Get(int id)
        {
            PlanillaDePago planilla = db.PlanillaDePago.Find(id);
            if (planilla == null)
            {
                return NotFound();
            }
            return Ok(planilla);
        }

        /// <summary>
        /// Crea una nueva PlanillaDePago
        /// </summary>
        /// <param name="planilla"></param>
        /// <returns>JSON PlanillaDePago</returns>
        /// <response code="200">Devuelve el valor creado</response>
        /// <response code="400">Si el modelo es inválido</response>
        // POST: api/PlanillaDePago
        public IHttpActionResult Post(PlanillaDePago planilla)
        {
            if (planilla.Estado != null)
            {
                Estado estadoEncontrado = db.Estado.Find(planilla.Estado.idEstado);
                planilla.Estado = estadoEncontrado;
            }

            db.PlanillaDePago.Add(planilla);
            db.SaveChanges();

            return Ok(planilla);
        }

        /// <summary>
        /// Modifica una PlanillaDePago
        /// </summary>
        /// <param name="planillaModificada"></param>
        /// <returns>JSON PlanillaDePago</returns>
        /// <response code="200">Devuelve el valor modificado</response>
        /// <response code="400">Si el modelo es inválido</response>
        // PUT: api/PlanillaDePago
        public IHttpActionResult Put(PlanillaDePago planillaModificada)
        {
            db.Entry(planillaModificada).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(planillaModificada);
        }

        /// <summary>
        /// Elimina una PlanillaDePago por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON PlanillaDePago</returns>
        /// <response code="200">Devuelve el valor eliminado</response>
        /// <response code="404">Si no se encuentra el valor</response>
        // DELETE: api/PlanillaDePago/5
        public IHttpActionResult Delete(int id)
        {
            PlanillaDePago planilla = db.PlanillaDePago.Find(id);
            if (planilla == null)
            {
                return NotFound();
            }

            db.PlanillaDePago.Remove(planilla);
            db.SaveChanges();

            return Ok(planilla);
        }
    }
}

