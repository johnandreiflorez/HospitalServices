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
    public class MedicoController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Medico
        [HttpGet]
        public List<Medico> GetAll()
        {
            return dbHospital.Medicos.ToList();
        }

        // POST: Medico/Create
        [HttpPost]
        public Medico Create(Medico medico)
        {
            Medico result = dbHospital.Medicos.Add(medico);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Medico/Details/5
        //[HttpGet]
        //public Medico Get(int id)
        //{
        //    Medico dbMedico = dbHospital.Medicos.Where(x => x.ID == id).FirstOrDefault();
        //    return dbMedico;
        //}

        // PUT: Medico/Edit
        [HttpPut]
        public string Edit(Medico medico)
        {
            Medico dbMedico = dbHospital.Medicos.Where(x => x.ID == medico.ID).FirstOrDefault();
            dbMedico.Nombre = medico.Nombre;
            dbMedico.Apellido = medico.Apellido;
            dbMedico.Dirección = medico.Dirección;
            dbMedico.Teléfono = medico.Teléfono;
            dbMedico.Especialidad = medico.Especialidad;
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Medico/Delete/5
        [HttpDelete]
        public Medico Delete(int id)
        {
            Medico dbMedico = dbHospital.Medicos.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Medicos.Remove(dbMedico);
            dbHospital.SaveChanges();
            return dbMedico;
        }
    }
}