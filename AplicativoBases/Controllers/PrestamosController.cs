using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class PrestamosController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Prestamos
        public IEnumerable<Prestamos> Get()
        {
            return db.Prestamos;
        }

        // GET: api/Prestamos/5
        public IHttpActionResult Get(int id)
        {
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return NotFound();
            }
            return Ok(prestamos);
        }

        // POST: api/Prestamos
        public IHttpActionResult Post(Prestamos prestamos)
        {
            if (prestamos.Sucripcion != null)
            {
                var sucripcionEncontrada = db.Sucripcion.Find(prestamos.Sucripcion.idSucripcion);
                prestamos.Sucripcion = sucripcionEncontrada;
            }

            db.Prestamos.Add(prestamos);
            db.SaveChanges();

            return Ok(prestamos);
        }

        // PUT: api/Prestamos
        public IHttpActionResult Put(Prestamos prestamosModificado)
        {
            db.Entry(prestamosModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(prestamosModificado);
        }

        // DELETE: api/Prestamos/5
        public IHttpActionResult Delete(int id)
        {
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return NotFound();
            }
            db.Prestamos.Remove(prestamos);
            db.SaveChanges();

            return Ok(prestamos);
        }
    }
}
