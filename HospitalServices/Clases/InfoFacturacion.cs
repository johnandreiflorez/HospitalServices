using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class InfoFacturacion
    {
        public int IDIngreso { get; set; }
        public string Paciente { get; set; }
        public string Cedula{ get; set; }
        public string FechaIngreso { get; set; }
        public string Habitacion { get; set; }
        public Decimal PrecioHabitacion { get; set; }

    }
}