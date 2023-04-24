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
    public class IngresoController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Ingreso
        [HttpGet]
        public List<infoIngreso> GetAll()
        {
            var result = (from I in dbHospital.Ingresoes
                       join H in dbHospital.Habitacions on I.ID_Habitacion equals H.ID
                       join TH in dbHospital.Tipo_Habitacion on H.ID_Tipo_Habitacion equals TH.ID
                       join P in dbHospital.Pacientes on I.ID_Paciente equals P.ID
                       select new infoIngreso {
                           ID = I.ID,
                           Paciente = P.Nombre,
                           Habitacion = TH.Nombre,
                           Fecha_Ingreso = I.Fecha_ingreso.ToString(),
                           Fecha_Salida = I.Fecha_salida.ToString()
                       }).ToList();
            return result;
        }

        // POST: Ingreso/Create
        [HttpPost]
        public Ingreso Create(Ingreso ingreso)
        {
            Ingreso result = dbHospital.Ingresoes.Add(ingreso);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Ingreso/Details/5
        //[HttpGet]
        //public Ingreso Get(int id)
        //{
        //    Ingreso dbIngreso = dbHospital.Ingresoes.Where(x => x.ID == id).FirstOrDefault();
        //    return dbIngreso;
        //}

        // PUT: Ingreso/Edit
        [HttpPut]
        public string Edit(Ingreso ingreso)
        {
            Ingreso dbIngreso = dbHospital.Ingresoes.Where(x => x.ID == ingreso.ID).FirstOrDefault();
            dbIngreso.Fecha_ingreso = ingreso.Fecha_ingreso;
            dbIngreso.Fecha_salida = ingreso.Fecha_salida;
            dbIngreso.ID_Habitacion = ingreso.ID_Habitacion;
            dbIngreso.ID_Paciente = ingreso.ID_Paciente;
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Ingreso/Delete/5
        [HttpDelete]
        public Ingreso Delete(int id)
        {
            Ingreso dbIngreso = dbHospital.Ingresoes.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Ingresoes.Remove(dbIngreso);
            dbHospital.SaveChanges();
            return dbIngreso;
        }
    }
}