using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class Empleado_has_FacturacionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Empleado_has_Facturacion
        public IHttpActionResult Get()
        {
            var relaciones = db.Empleado_has_Facturacion.ToList();
            return Ok(relaciones);
        }

        // GET: api/Empleado_has_Facturacion/5
        public IHttpActionResult Get(int id)
        {
            var relacion = db.Empleado_has_Facturacion.FirstOrDefault(r => r.idEmpleado == id);
            if (relacion == null)
                return NotFound();

            return Ok(relacion);
        }

        // POST: api/Empleado_has_Facturacion
        public IHttpActionResult Post(Empleado_has_Facturacion relacion)
        {
            if (relacion.Empleado != null)
            {
                Empleado empleadoEncontrado = db.Empleado.Find(relacion.Empleado.idEmpleado);
                relacion.Empleado = empleadoEncontrado;
            }

            if (relacion.Facturacion != null)
            {
                Facturacion facturacionEncontrada = db.Facturacion.Find(relacion.Facturacion.idFacturacion);
                relacion.Facturacion = facturacionEncontrada;
            }

            db.Empleado_has_Facturacion.Add(relacion);
            db.SaveChanges();

            return Ok(relacion);
        }

        // PUT: api/Empleado_has_Facturacion/5
        public IHttpActionResult Put(int id, Empleado_has_Facturacion relacion)
        {
            var existente = db.Empleado_has_Facturacion.FirstOrDefault(r => r.idEmpleado == id && r.idFacturacion == relacion.idFacturacion);
            if (existente == null)
                return NotFound();

            if (relacion.Empleado != null)
            {
                Empleado empleadoEncontrado = db.Empleado.Find(relacion.Empleado.idEmpleado);
                existente.Empleado = empleadoEncontrado;
                existente.idEmpleado = relacion.idEmpleado;
            }

            if (relacion.Facturacion != null)
            {
                Facturacion facturacionEncontrada = db.Facturacion.Find(relacion.Facturacion.idFacturacion);
                existente.Facturacion = facturacionEncontrada;
                existente.idFacturacion = relacion.idFacturacion;
            }

            db.SaveChanges();
            return Ok(existente);
        }

        // DELETE: api/Empleado_has_Facturacion/5
        public IHttpActionResult Delete(int id)
        {
            var relacion = db.Empleado_has_Facturacion.FirstOrDefault(r => r.idEmpleado == id);
            if (relacion == null)
                return NotFound();

            db.Empleado_has_Facturacion.Remove(relacion);
            db.SaveChanges();

            return Ok();
        }
    }
}
