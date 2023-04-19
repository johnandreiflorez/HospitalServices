using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HospitalServices.Models;


namespace HospitalServices.Controllers
{
    [EnableCors(origins: "http://localhost:62289", headers: "*", methods: "*")]
    public class TipoHabitacionController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();
        // GET: Tipo_Habitacion
        [HttpGet]
        public List<Tipo_Habitacion> GetAll()
        {
            var response = dbHospital.Tipo_Habitacion.ToList();
            return response;
        }
    }
}