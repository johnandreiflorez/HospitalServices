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
            var result = dbHospital.Ingresoes.Select(x => new infoIngreso
            {
                ID = x.ID,
                Paciente = x.Paciente.Nombre,
                Habitacion = x.Habitacion.Tipo,
                Fecha_Ingreso = x.Fecha_ingreso.ToString(),
                Fecha_Salida = x.Fecha_salida.ToString()
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