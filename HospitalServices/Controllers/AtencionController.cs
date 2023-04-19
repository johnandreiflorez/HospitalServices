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
    public class AtencionController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Atencion
        [HttpGet]
        public List<InfoAtencion> GetAll()
        {
            //return dbHospital.Atencions.ToList();

            var result = dbHospital.Atencions.Select(x => new InfoAtencion
            {
                ID = x.ID,
                Medico = x.Medico.Nombre,
                Enfermera = x.Enfermera.Nombre,
                Paciente = x.Paciente.Nombre,
                Ingreso = x.Ingreso.Fecha_ingreso.ToString(),
                Fecha = x.Fecha.ToString(),
                Notas = x.Notas
            }).ToList();
            return result;
        }

        // POST: Atencion/Create
        [HttpPost]
        public Atencion Create(Atencion atencion)
        {
            Atencion result = dbHospital.Atencions.Add(atencion);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Atencion/Details/5
        //[HttpGet]
        //public Atencion Get(int id)
        //{
        //    Atencion dbAtencion = dbHospital.Atencions.Where(x => x.ID == id).FirstOrDefault();
        //    return dbAtencion;
        //}

        // PUT: Atencion/Edit
        [HttpPut]
        public string Edit(Atencion atencion)
        {
            Atencion dbAtencion = dbHospital.Atencions.Where(x => x.ID == atencion.ID).FirstOrDefault();
            dbAtencion.ID_Enfermera = atencion.ID_Enfermera;
            dbAtencion.ID_Ingreso = atencion.ID_Ingreso;
            dbAtencion.ID_Medico = atencion.ID_Medico;
            dbAtencion.ID_Paciente = atencion.ID_Paciente;
            dbAtencion.Fecha = atencion.Fecha;
            dbAtencion.Notas = atencion.Notas;
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Atencion/Delete/5
        [HttpDelete]
        public Atencion Delete(int id)
        {
            Atencion dbAtencion = dbHospital.Atencions.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Atencions.Remove(dbAtencion);
            dbHospital.SaveChanges();
            return dbAtencion;
        }
    }
}