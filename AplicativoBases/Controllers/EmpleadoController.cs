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
    public class EmpleadoController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Empleados
        /// </summary>
        /// <returns>JSON Empleados</returns>
        /// <response code="200">Devuelve la lista de empleados</response>
        /// <response code="404">Si no se encuentra ningún registro</response>
        public IEnumerable<Empleado> Get()
        {
            return db.Empleado;
        }

        /// <summary>
        ///  Obtener un Empleado por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Empleado</returns>
        /// <response code="200">Devuelve el empleado encontrado</response>
        /// <response code="404">Si no se encuentra el empleado</response>
        public IHttpActionResult Get(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        /// <summary>
        ///  Crear un nuevo Empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns>JSON del empleado creado</returns>
        /// <response code="200">Empleado creado correctamente</response>
        /// <response code="400">Error al crear el empleado</response>
        public IHttpActionResult Post(Empleado empleado)
        {
            db.Empleado.Add(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }

        /// <summary>
        ///  Modificar un Empleado existente
        /// </summary>
        /// <param name="empleadoModificado"></param>
        /// <returns>JSON del empleado actualizado</returns>
        /// <response code="200">Empleado actualizado</response>
        /// <response code="404">Empleado no encontrado</response>
        public IHttpActionResult Put(Empleado empleadoModificado)
        {
            if (!db.Empleado.Any(e => e.idEmpleado == empleadoModificado.idEmpleado))
            {
                return NotFound();
            }

            db.Entry(empleadoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(empleadoModificado);
        }

        /// <summary>
        ///  Eliminar un Empleado por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON del empleado eliminado</returns>
        /// <response code="200">Empleado eliminado</response>
        /// <response code="404">Empleado no encontrado</response>
        public IHttpActionResult Delete(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.Empleado.Remove(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }
    }
}
