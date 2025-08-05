using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class FacturacionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Facturacion
        public IHttpActionResult Get()
        {
            var facturaciones = db.Facturacion.ToList();
            return Ok(facturaciones);
        }

        // GET: api/Facturacion/5
        public IHttpActionResult Get(int id)
        {
            var facturacion = db.Facturacion.Find(id);
            if (facturacion == null)
                return NotFound();

            return Ok(facturacion);
        }

        // POST: api/Facturacion
        public IHttpActionResult Post(Facturacion facturacion)
        {
            if (facturacion.Cliente != null)
            {
                Cliente clienteEncontrado = db.Cliente.Find(facturacion.Cliente.IdCliente);
                facturacion.Cliente = clienteEncontrado;
            }

            if (facturacion.Metodo_De_Pago != null)
            {
                Metodo_De_Pago metodoEncontrado = db.Metodo_De_Pago.Find(facturacion.Metodo_De_Pago.idMetodo_De_Pago);
                facturacion.Metodo_De_Pago = metodoEncontrado;
            }

            db.Facturacion.Add(facturacion);
            db.SaveChanges();

            return Ok(facturacion);
        }

        // PUT: api/Facturacion/5
        public IHttpActionResult Put(int id, Facturacion facturacion)
        {
            var facturacionExistente = db.Facturacion.Find(id);
            if (facturacionExistente == null)
                return NotFound();

            if (facturacion.Cliente != null)
            {
                Cliente clienteEncontrado = db.Cliente.Find(facturacion.Cliente.IdCliente);
                facturacionExistente.Cliente = clienteEncontrado;
                facturacionExistente.Cliente_idCliente = facturacion.Cliente_idCliente;
            }

            if (facturacion.Metodo_De_Pago != null)
            {
                Metodo_De_Pago metodoEncontrado = db.Metodo_De_Pago.Find(facturacion.Metodo_De_Pago.idMetodo_De_Pago);
                facturacionExistente.Metodo_De_Pago = metodoEncontrado;
                facturacionExistente.Metodo_De_Pago_idMetodo_De_Pago = facturacion.Metodo_De_Pago_idMetodo_De_Pago;
            }

            facturacionExistente.MontoTotal = facturacion.MontoTotal;

            db.Entry(facturacionExistente).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(facturacionExistente);
        }

        // DELETE: api/Facturacion/5
        public IHttpActionResult Delete(int id)
        {
            var facturacion = db.Facturacion.Find(id);
            if (facturacion == null)
                return NotFound();

            db.Facturacion.Remove(facturacion);
            db.SaveChanges();

            return Ok();
        }
    }
}
