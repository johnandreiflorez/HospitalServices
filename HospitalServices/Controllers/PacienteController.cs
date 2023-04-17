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
    public class PacienteController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Paciente
        [EnableCors(origins: "http://localhost:62289", headers: "*", methods: "*")]
        [HttpGet]
        public List<Paciente> GetAll()
        {
            //return dbHospital.Pacientes.Select(x => new PacienteInfo { Nombre = x.Nombre, Apellido = x.Apellido, Teléfono = x.Teléfono, Dirección = x.Dirección }).ToList();
            var response = dbHospital.Pacientes.ToList();
            return response;
        }
       
        //public List<Paciente> GETACTIVE()
        //{
        //     //return dbHospital.Pacientes.Where(x => x.Ingresoes.Where(z => z.Fecha_salida == null).FirstOrDefault().Fecha_salida == null).ToList();
        //    return (from p in dbHospital.Pacientes join i in dbHospital.Ingresoes on p.ID equals i.ID_Paciente where i.Fecha_salida == null && i.Fecha_ingreso != null select p).ToList();
        //}

        // GET: Paciente/Details/5
        //[HttpGet]
        //public Paciente Get(int id)
        //{
        //    Paciente dbPaciente = dbHospital.Pacientes.Where(x => x.ID == id).FirstOrDefault();
        //    return dbPaciente;
        //}

        // POST: Paciente/Create
        [HttpPost]
        public Paciente Create([FromBody] Paciente paciente)
        {
            Paciente result = dbHospital.Pacientes.Add(paciente);
            dbHospital.SaveChanges();
            return result;
        }

        // PUT: Paciente/Edit
        [HttpPut]
        public string Edit(Paciente paciente)
        {
            Paciente dbPaciente = dbHospital.Pacientes.Where(x => x.ID == paciente.ID).FirstOrDefault();
            dbPaciente.Nombre = paciente.Nombre;
            dbPaciente.Apellido = paciente.Apellido;
            dbPaciente.Dirección = paciente.Dirección;
            dbPaciente.Teléfono = paciente.Teléfono;
            dbPaciente.Fecha_nacimiento = paciente.Fecha_nacimiento;
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Paciente/Delete?id=5
        [HttpDelete]
        public Paciente Delete(int id)
        {
            Paciente dbPaciente = dbHospital.Pacientes.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Pacientes.Remove(dbPaciente);
            dbHospital.SaveChanges();
            return dbPaciente;
        }
    }
}