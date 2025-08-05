using AplicativoBases.Models;
using ProyectoAeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class Historico_De_CargosController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Muestra todos los registros de Historico_De_Cargos
        /// </summary>
        /// <returns>JSON de Historico_De_Cargos</returns>
        public IEnumerable<Historico_De_Cargos> Get()
        {
            return db.Historico_De_Cargos;
        }

        /// <summary>
        /// Obtener un registro de Historico_De_Cargos por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON de Historico_De_Cargos</returns>
        public IHttpActionResult Get(int id)
        {
            var historico = db.Historico_De_Cargos
                .Include(h => h.Cargo)
                .Include(h => h.Empleado)
                .FirstOrDefault(h => h.idCargo == id);

            if (historico == null)
                return NotFound();

            return Ok(historico);
        }

        /// <summary>
        /// Crear un nuevo registro en Historico_De_Cargos
        /// </summary>
        /// <param name="historico"></param>
        /// <returns>JSON de Historico_De_Cargos</returns>
        public IHttpActionResult Post(Historico_De_Cargos historico)
        {
            if (historico.Cargo != null)
            {
                var cargoEncontrado = db.Cargo.Find(historico.Cargo.idCargo);
                historico.Cargo = cargoEncontrado;
            }

            if (historico.Empleado != null)
            {
                var empleadoEncontrado = db.Empleado.Find(historico.Empleado.idEmpleado);
                historico.Empleado = empleadoEncontrado;
            }

            db.Historico_De_Cargos.Add(historico);
            db.SaveChanges();

            return Ok(historico);
        }

        /// <summary>
        /// Modificar un registro de Historico_De_Cargos
        /// </summary>
        /// <param name="historicoModificado"></param>
        /// <returns>JSON de Historico_De_Cargos</returns>
        public IHttpActionResult Put(Historico_De_Cargos historicoModificado)
        {
            db.Entry(historicoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(historicoModificado);
        }

        /// <summary>
        /// Eliminar un registro de Historico_De_Cargos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON de Historico_De_Cargos</returns>
        public IHttpActionResult Delete(int id)
        {
            var historico = db.Historico_De_Cargos.Find(id);
            if (historico == null)
                return NotFound();

            db.Historico_De_Cargos.Remove(historico);
            db.SaveChanges();

            return Ok(historico);
        }
    }
}
