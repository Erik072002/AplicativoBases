using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class Beneficios_has_SucripcionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Beneficios_has_Sucripcion
        public IEnumerable<Beneficios_has_Sucripcion> Get()
        {
            return db.Beneficios_has_Sucripcion.ToList();
        }

        // GET: api/Beneficios_has_Sucripcion/5/3
        [Route("api/Beneficios_has_Sucripcion/{idBeneficios}/{idSucripcion}")]
        public IHttpActionResult Get(int idBeneficios, int idSucripcion)
        {
            var relacion = db.Beneficios_has_Sucripcion
                .FirstOrDefault(r => r.idBeneficios == idBeneficios && r.idSucripcion == idSucripcion);

            if (relacion == null)
                return NotFound();

            return Ok(relacion);
        }

        // POST: api/Beneficios_has_Sucripcion
        public IHttpActionResult Post(Beneficios_has_Sucripcion relacion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Beneficios_has_Sucripcion.Add(relacion);
            db.SaveChanges();

            return Ok(relacion);
        }

        // PUT: api/Beneficios_has_Sucripcion/5/3
        [Route("api/Beneficios_has_Sucripcion/{idBeneficios}/{idSucripcion}")]
        public IHttpActionResult Put(int idBeneficios, int idSucripcion, Beneficios_has_Sucripcion relacion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Actualiza solo si las relaciones no son 0
            if (relacion.idBeneficios != 0)
                db.Beneficios_has_Sucripcion.FirstOrDefault(r => r.idBeneficios == idBeneficios && r.idSucripcion == idSucripcion).idBeneficios = relacion.idBeneficios;

            if (relacion.idSucripcion != 0)
                db.Beneficios_has_Sucripcion.FirstOrDefault(r => r.idBeneficios == idBeneficios && r.idSucripcion == idSucripcion).idSucripcion = relacion.idSucripcion;

            db.SaveChanges();

            return Ok(relacion);
        }

        // DELETE: api/Beneficios_has_Sucripcion/5/3
        [Route("api/Beneficios_has_Sucripcion/{idBeneficios}/{idSucripcion}")]
        public IHttpActionResult Delete(int idBeneficios, int idSucripcion)
        {
            var relacion = db.Beneficios_has_Sucripcion
                .FirstOrDefault(r => r.idBeneficios == idBeneficios && r.idSucripcion == idSucripcion);

            if (relacion == null)
                return NotFound();

            db.Beneficios_has_Sucripcion.Remove(relacion);
            db.SaveChanges();

            return Ok(relacion);
        }
    }
}
