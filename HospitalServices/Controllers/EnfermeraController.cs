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
    public class EnfermeraController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Enfermera
        [HttpGet]
        public List<Enfermera> GetAll()
        {
            return dbHospital.Enfermeras.ToList();
        }

        // POST: Enfermera/Create
        [HttpPost]
        public Enfermera Create(Enfermera enfermera)
        {
            Enfermera result = dbHospital.Enfermeras.Add(enfermera);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Enfermera/Details/5
        //[HttpGet]
        //public Enfermera Get(int id)
        //{
        //    Enfermera dbEnfermera = dbHospital.Enfermeras.Where(x => x.ID == id).FirstOrDefault();
        //    return dbEnfermera;
        //}

        // PUT: Enfermera/Edit
        [HttpPut]
        public string Edit(Enfermera enfermera)
        {
            Enfermera dbEnfermera = dbHospital.Enfermeras.Where(x => x.ID == enfermera.ID).FirstOrDefault();
            dbEnfermera.Nombre = enfermera.Nombre;
            dbEnfermera.Apellido = enfermera.Apellido;
            dbEnfermera.Dirección = enfermera.Dirección;
            dbEnfermera.Teléfono = enfermera.Teléfono;
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Enfermera/Delete/5
        [HttpDelete]
        public Enfermera Delete(int id)
        {
            Enfermera dbEnfermera = dbHospital.Enfermeras.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Enfermeras.Remove(dbEnfermera);
            dbHospital.SaveChanges();
            return dbEnfermera;
        }
    }
}