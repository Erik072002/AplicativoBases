using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class ResenaController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Resena
        public IHttpActionResult Get()
        {
            var resenas = db.Resena.ToList();
            return Ok(resenas);
        }

        // GET: api/Resena/5
        public IHttpActionResult Get(int id)
        {
            var resena = db.Resena.Find(id);
            if (resena == null)
                return NotFound();

            return Ok(resena);
        }

        // POST: api/Resena
        public IHttpActionResult Post(Resena resena)
        {
            if (resena.Cliente != null)
            {
                Cliente clienteEncontrado = db.Cliente.Find(resena.Cliente.IdCliente);
                resena.Cliente = clienteEncontrado;
            }

            if (resena.Libro != null)
            {
                Libro libroEncontrado = db.Libro.Find(resena.Libro.IdLibro);
                resena.Libro = libroEncontrado;
            }

            db.Resena.Add(resena);
            db.SaveChanges();

            return Ok(resena);
        }

        // PUT: api/Resena/5
        public IHttpActionResult Put(int id, Resena resena)
        {
            var resenaExistente = db.Resena.Find(id);
            if (resenaExistente == null)
                return NotFound();

            if (resena.Cliente != null)
            {
                Cliente clienteEncontrado = db.Cliente.Find(resena.Cliente.IdCliente);
                resenaExistente.Cliente = clienteEncontrado;
                resenaExistente.idCliente = resena.idCliente;
            }

            if (resena.Libro != null)
            {
                Libro libroEncontrado = db.Libro.Find(resena.Libro.IdLibro);
                resenaExistente.Libro = libroEncontrado;
                resenaExistente.idLibro = resena.idLibro;
            }

            resenaExistente.Calificacion = resena.Calificacion;
            resenaExistente.Comentario = resena.Comentario;
            resenaExistente.Fecha = resena.Fecha;

            db.Entry(resenaExistente).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(resenaExistente);
        }

        // DELETE: api/Resena/5
        public IHttpActionResult Delete(int id)
        {
            var resena = db.Resena.Find(id);
            if (resena == null)
                return NotFound();

            db.Resena.Remove(resena);
            db.SaveChanges();

            return Ok();
        }
    }
}
