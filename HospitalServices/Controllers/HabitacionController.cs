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
    public class HabitacionController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Habitacion
        [HttpGet]
        public List<Habitacion> GetAll()
        {
            return dbHospital.Habitacions.ToList();
        }

        // POST: Habitacion/Create
        [HttpPost]
        public Habitacion Create(Habitacion habitacion)
        {
            Habitacion result = dbHospital.Habitacions.Add(habitacion);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Habitacion/Details/5
        //[HttpGet]
        //public Habitacion Get(int id)
        //{
        //    Habitacion dbHabitacion = dbHospital.Habitacions.Where(x => x.ID == id).FirstOrDefault();
        //    return dbHabitacion;
        //}

        // PUT: Habitacion/Edit
        [HttpPut]
        public string Edit(Habitacion habitacion)
        {
            Habitacion dbHabitacion = dbHospital.Habitacions.Where(x => x.ID == habitacion.ID).FirstOrDefault();
            dbHabitacion.Precio = habitacion.Precio;
            dbHabitacion.Tipo = habitacion.Tipo;
            
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Habitacion/Delete/5
        [HttpDelete]
        public Habitacion Delete(int id)
        {
            Habitacion dbHabitacion = dbHospital.Habitacions.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Habitacions.Remove(dbHabitacion);
            dbHospital.SaveChanges();
            return dbHabitacion;
        }
    }
}