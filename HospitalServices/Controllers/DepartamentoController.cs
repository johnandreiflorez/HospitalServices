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
    public class DepartamentoController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();
        // GET: Departamento
        [HttpGet]
        public List<Departamento> GetAll()
        {
            var response = dbHospital.Departamentoes.ToList();
            return response;
        }
    }
}