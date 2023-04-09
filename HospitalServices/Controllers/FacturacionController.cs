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
    [EnableCors(origins: "http://localhost:62289", methods:"*", headers:"*")]
    public class FacturacionController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Facturacion
        [HttpGet]
        public List<Facturacion> GetAll()
        {
            return dbHospital.Facturacions.ToList();
        }

        // POST: Facturacion/Create
        [HttpPost]
        public Facturacion Create(Facturacion facturacion)
        {
            Facturacion result = dbHospital.Facturacions.Add(facturacion);
            dbHospital.SaveChanges();
            return result;
        }

        // GET: Facturacion/Details/5
        //[HttpGet]
        //public Facturacion Get(int id)
        //{
        //    Facturacion dbFacturacion = dbHospital.Facturacions.Where(x => x.ID == id).FirstOrDefault();
        //    return dbFacturacion;
        //}

        // PUT: Facturacion/Edit
        [HttpPut]
        public string Edit(Facturacion facturacion)
        {
            Facturacion dbFacturacion = dbHospital.Facturacions.Where(x => x.ID == facturacion.ID).FirstOrDefault();
            dbFacturacion.ID_Ingreso = facturacion.ID_Ingreso;
            dbFacturacion.Valor = facturacion.Valor;
            dbFacturacion.FechaFacturacion = facturacion.FechaFacturacion;
            dbFacturacion.FechaPago = facturacion.FechaPago;
            dbHospital.SaveChanges();
            return "Se actualizo de manera correcta";
        }

        // Delete: Facturacion/Delete/5
        [HttpDelete]
        public Facturacion Delete(int id)
        {
            Facturacion dbFacturacion = dbHospital.Facturacions.Where(x => x.ID == id).FirstOrDefault();
            dbHospital.Facturacions.Remove(dbFacturacion);
            dbHospital.SaveChanges();
            return dbFacturacion;
        }
    }
}