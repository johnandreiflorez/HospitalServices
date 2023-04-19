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
    public class AsignacionTratamientoController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Tratamiento_asignado
        [HttpGet]
        public List<InfoTratamientoAsignado> GetAll()
        {
            var result = (from ta in dbHospital.Tratamiento_asignado
                          join i in dbHospital.Ingresoes on ta.ID_Ingreso equals i.ID
                          join p in dbHospital.Pacientes on i.ID_Paciente equals p.ID
                          join t in dbHospital.Tratamientoes on ta.ID_Tratamiento equals t.ID select new InfoTratamientoAsignado{
                              ID = ta.ID,
                              Tratamiento = t.Nombre,
                              Paciente = p.Nombre,
                              Fecha_Inicio = ta.Fecha_inicio.ToString(),
                              Fecha_Fin = ta.Fecha_fin.ToString()
                          }).ToList();
            return result;
        }

        // POST: Tratamiento_asignado/Create
        [HttpPost]
        public Tratamiento_asignado Create(Tratamiento_asignado tratamientoAsignado)
        {
            Tratamiento_asignado result = dbHospital.Tratamiento_asignado.Add(tratamientoAsignado);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Tratamiento_asignado/Details/5
        //[HttpGet]
        //public Tratamiento_asignado Get(int id)
        //{
        //    Tratamiento_asignado dbTratamiento_asignado = dbHospital.Tratamiento_asignado.Where(x => x.ID == id).FirstOrDefault();
        //    return dbTratamiento_asignado;
        //}

        // PUT: Tratamiento_asignado/Edit
        [HttpPut]
        public string Edit(Tratamiento_asignado tratamientoAsignado)
        {
            Tratamiento_asignado dbTratamiento_asignado = dbHospital.Tratamiento_asignado.Where(x => x.ID == tratamientoAsignado.ID).FirstOrDefault();
            dbTratamiento_asignado.Fecha_fin = tratamientoAsignado.Fecha_fin;
            dbTratamiento_asignado.Fecha_inicio = tratamientoAsignado.Fecha_inicio;
            dbTratamiento_asignado.ID_Ingreso = tratamientoAsignado.ID_Ingreso;
            dbTratamiento_asignado.ID_Tratamiento = tratamientoAsignado.ID_Tratamiento;
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Tratamiento_asignado/Delete/5
        [HttpDelete]
        public Tratamiento_asignado Delete(int id)
        {
            Tratamiento_asignado dbTratamiento_asignado = dbHospital.Tratamiento_asignado.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Tratamiento_asignado.Remove(dbTratamiento_asignado);
            dbHospital.SaveChanges();
            return dbTratamiento_asignado;
        }
    }
}