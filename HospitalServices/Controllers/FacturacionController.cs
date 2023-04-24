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
    [EnableCors(origins: "http://localhost:62289", methods: "*", headers: "*")]
    public class FacturacionController : ApiController
    {
        private DBHospital dbHospital = new DBHospital();

        // GET: Facturacion
        [HttpGet]
        public List<InfoFacturacion> GetAll()
        {
            var response = (from i in dbHospital.Ingresoes
                            join p in dbHospital.Pacientes on i.ID_Paciente equals p.ID
                            join h in dbHospital.Habitacions on i.ID_Habitacion equals h.ID
                            join th in dbHospital.Tipo_Habitacion on h.ID_Tipo_Habitacion equals th.ID
                            join d in dbHospital.Departamentoes on h.ID_Departamento equals d.ID
                            where i.Fecha_salida == null
                            select new InfoFacturacion
                            {
                                Cedula = p.Cedula,
                                Paciente = p.Nombre,
                                Habitacion = th.Nombre + ": " + th.Descripcion + ", ubicada en el departamento: " + d.Nombre + ", piso: " + h.Tipo,
                                FechaIngreso = i.Fecha_ingreso.ToString(),
                                PrecioHabitacion = h.Precio.Value,
                                IDIngreso = i.ID
                            }).ToList();
            return response;
        }

        // POST: Facturacion/Create
        [HttpPost]
        public Facturacion Create(Facturacion facturacion)
        {
            Ingreso ingreso = dbHospital.Ingresoes.Where(x => x.ID == facturacion.ID_Ingreso).FirstOrDefault();
            ingreso.Fecha_salida = facturacion.FechaFacturacion;
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
            Ingreso dbIngreso = dbHospital.Ingresoes.Where(x => x.ID == dbFacturacion.ID_Ingreso).FirstOrDefault();
            dbIngreso.Fecha_salida = null;
            dbHospital.Facturacions.Remove(dbFacturacion);
            dbHospital.SaveChanges();
            return dbFacturacion;
        }

        [HttpPatch]
        public List<InfoFacturados> GetFacturados()
        {
            var response = (from i in dbHospital.Ingresoes
                            join p in dbHospital.Pacientes on i.ID_Paciente equals p.ID
                            join h in dbHospital.Habitacions on i.ID_Habitacion equals h.ID
                            join th in dbHospital.Tipo_Habitacion on h.ID_Tipo_Habitacion equals th.ID
                            join d in dbHospital.Departamentoes on h.ID_Departamento equals d.ID
                            join f in dbHospital.Facturacions on i.ID equals f.ID_Ingreso
                            where i.Fecha_salida != null
                            select new InfoFacturados
                            {
                                ID = f.ID,
                                FechaPago = f.FechaPago.ToString(),
                                Cedula = p.Cedula,
                                Paciente = p.Nombre,
                                Habitacion = th.Nombre + ": " + th.Descripcion + ", ubicada en el departamento: " + d.Nombre + ", piso: " + h.Tipo,
                                FechaIngreso = i.Fecha_ingreso.ToString(),
                                PrecioHabitacion = h.Precio.Value,
                                IDIngreso = i.ID,
                                FechaSalida = i.Fecha_salida.ToString(),
                            }).ToList();
            foreach (var item in response)
            {
                item.calcularValor();
            }
            return response;    
        }
    }
}