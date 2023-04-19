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
    public class MedicamentoController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();
        // GET: Medicamento
        [HttpGet]
        public List<Medicamento> GetAll()
        {
            var response = dbHospital.Medicamentoes.ToList();
            return response;
        }
    }
}