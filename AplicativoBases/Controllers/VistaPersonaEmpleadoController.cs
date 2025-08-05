using ProyectoAeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AplicativoBases.Controllers
{
    public class VistaPersonaEmpleadoController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        
        public IHttpActionResult Get()
        {
            var data = db.VistaPersonaEmpleado.ToList();
            return Ok(data);
        }
    }
}
