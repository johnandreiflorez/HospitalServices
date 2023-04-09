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
    public class TratamientoController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Tratamiento
        [HttpGet]
        public List<Tratamiento> GetAll()
        {
            return dbHospital.Tratamientoes.ToList();
        }

        // POST: Tratamiento/Create
        [HttpPost]
        public Tratamiento Create(Tratamiento tratamiento)
        {
            Tratamiento result = dbHospital.Tratamientoes.Add(tratamiento);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Tratamiento/Details/5
        //[HttpGet]
        //public Tratamiento Get(int id)
        //{
        //    Tratamiento dbTratamiento = dbHospital.Tratamientoes.Where(x => x.ID == id).FirstOrDefault();
        //    return dbTratamiento;
        //}

        // PUT: Tratamiento/Edit
        [HttpPut]
        public string Edit(Tratamiento tratamiento)
        {
            Tratamiento dbTratamiento = dbHospital.Tratamientoes.Where(x => x.ID == tratamiento.ID).FirstOrDefault();
            dbTratamiento.Nombre = tratamiento.Nombre;
            dbTratamiento.Descripción = tratamiento.Descripción;
            dbTratamiento.Costo = tratamiento.Costo;
            
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Tratamiento/Delete/5
        [HttpDelete]
        public Tratamiento Delete(int id)
        {
            Tratamiento dbTratamiento = dbHospital.Tratamientoes.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Tratamientoes.Remove(dbTratamiento);
            dbHospital.SaveChanges();
            return dbTratamiento;
        }
    }
}