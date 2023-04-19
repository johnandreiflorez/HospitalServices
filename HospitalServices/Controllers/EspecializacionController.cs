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
    public class EspecializacionController : ApiController
    {

        private DBHospital dbHospital = new DBHospital();

        [HttpGet]
        // GET api/<controller>
        public List<Especializacion> GetAll()
        {
            var response = dbHospital.Especializacions.ToList();
            return response;
        }
    }
}