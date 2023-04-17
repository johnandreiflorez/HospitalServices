using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HospitalServices.Models;
using HospitalServices.Clases;

namespace HospitalServices.Controllers
{
    [EnableCors(origins: "http://localhost:62289", headers: "*", methods: "*")]
    public class MedicamentoTratamientoController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();
        // GET: Medicamento_Tratamiento
        [HttpGet]
        public List<infoMedicamento> GetAll(int ID)
        {
            var response = (from mt in dbHospital.Medicamento_Tratamiento 
                            join m in dbHospital.Medicamentoes on mt.ID_Medicamento equals m.ID
                            where mt.ID_Tratamiento == ID
                            select new infoMedicamento { ID = m.ID, Medicamento =  m.Nombre}).ToList();
            return response;
        }
        [HttpPost]
        public bool Create(List<Medicamento_Tratamiento> medicamento_Tratamiento)
        {
            try
            {
                foreach (var item in medicamento_Tratamiento)
                {
                    dbHospital.Medicamento_Tratamiento.Add(item);
                }
                dbHospital.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}