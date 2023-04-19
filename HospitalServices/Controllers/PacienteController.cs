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

        [HttpPatch]
        public List<Paciente> GetPacientes()
        {
            var response = (from p in dbHospital.Pacientes 
                            join i in dbHospital.Ingresoes on p.ID equals i.ID_Paciente 
                            join h in dbHospital.Habitacions on i.ID_Habitacion equals h.ID
                            where i.Fecha_salida == null select p).ToList();
            return response;
        }

        // GET: Paciente
        [HttpGet]
        public List<PacienteInfo> GetAll()
        {
            var response = dbHospital.Pacientes.Select(x => new PacienteInfo {
                ID = x.ID,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Fecha_Nacimiento = x.Fecha_nacimiento.ToString(),
                Teléfono = x.Teléfono,
                Dirección = x.Dirección,
                Tipo_Documento = x.Tipo_Documento.Nombre,
                Documento = x.Cedula,
                }).ToList();
            //var response = dbHospital.Pacientes.ToList();
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
            dbPaciente.ID_Tipo_Documento = paciente.ID_Tipo_Documento;
            dbPaciente.Cedula = paciente.Cedula;
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