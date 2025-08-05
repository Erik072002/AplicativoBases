using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class SucripcionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Sucripcion
        [HttpGet]
        [Route("api/Suscripcion")]
        public IEnumerable<Sucripcion> Get()
        {
            return db.Sucripcion.ToList();
        }

        // GET: api/Sucripcion/5
        [HttpGet]
        [Route("api/SuscripcionId")]
        public IHttpActionResult Get(int id)
        {
            var sucripcion = db.Sucripcion.Find(id);
            if (sucripcion == null)
                return NotFound();

            return Ok(sucripcion);
        }

        // POST: api/Sucripcion
        public IHttpActionResult Post([FromBody] Sucripcion sucripcion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Sucripcion.Add(sucripcion);
            db.SaveChanges();

            return Ok(sucripcion);
        }

        // PUT: api/Sucripcion/5
        public IHttpActionResult Put(int id, [FromBody] Sucripcion sucripcion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = db.Sucripcion.Find(id);
            if (existente == null)
                return NotFound();

            existente.fecha_inicio = sucripcion.fecha_inicio;
            existente.costo = sucripcion.costo;

            if (sucripcion.Cliente_idCliente != 0)
                existente.Cliente_idCliente = sucripcion.Cliente_idCliente;

            if (sucripcion.Metodo_De_Pago_idMetodo_De_Pago != 0)
                existente.Metodo_De_Pago_idMetodo_De_Pago = sucripcion.Metodo_De_Pago_idMetodo_De_Pago;

            if (sucripcion.EstadoDeLaSuscripcion_idEstadoDeLaSuscripcion != 0)
                existente.EstadoDeLaSuscripcion_idEstadoDeLaSuscripcion = sucripcion.EstadoDeLaSuscripcion_idEstadoDeLaSuscripcion;

            if (sucripcion.NivelDeSuscripcion_idNivelDeSuscripcion != 0)
                existente.NivelDeSuscripcion_idNivelDeSuscripcion = sucripcion.NivelDeSuscripcion_idNivelDeSuscripcion;

            db.Entry(existente).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Sucripcion/5
        public IHttpActionResult Delete(int id)
        {
            var sucripcion = db.Sucripcion.Find(id);
            if (sucripcion == null)
                return NotFound();

            db.Sucripcion.Remove(sucripcion);
            db.SaveChanges();

            return Ok();
        }
    }
}
