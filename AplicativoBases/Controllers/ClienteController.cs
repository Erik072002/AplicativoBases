using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

namespace ProyectoAeropuerto.Controllers
{
    public class ClienteController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todos los Clientes
        /// </summary>
        /// <returns>JSON Cliente</returns>
        public IEnumerable<Cliente> Get()
        {
            return db.Cliente;
        }

        /// <summary>
        /// Obtener Cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Cliente</returns>
        public IHttpActionResult Get(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        /// <summary>
        /// Crear Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>JSON Cliente</returns>
        public IHttpActionResult Post(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente inválido");
            }

            db.Cliente.Add(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        /// <summary>
        /// Modificar Cliente
        /// </summary>
        /// <param name="id">ID del cliente</param>
        /// <param name="clienteModificado">Cliente con datos modificados</param>
        /// <returns>JSON Cliente</returns>
        [HttpPut]
        public IHttpActionResult Put(int id, Cliente clienteModificado)
        {
            if (clienteModificado == null)
            {
                return BadRequest("Cliente inválido");
            }

            if (id != clienteModificado.IdCliente)
            {
                return BadRequest("El ID de la URL no coincide con el del cliente enviado.");
            }

            var clienteExistente = db.Cliente.Find(id);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar campos específicos si no quieres sobreescribir todo
            clienteExistente.FechaRegistro = clienteModificado.FechaRegistro;
            clienteExistente.IdPersonas = clienteModificado.IdPersonas;

            db.SaveChanges();

            return Ok(clienteExistente);
        }


        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Cliente</returns>
        public IHttpActionResult Delete(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Cliente.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }
    }
}
