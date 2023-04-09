using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class infoIngreso
    {
        public int ID { get; set; }
        public string Paciente { get; set; }
        public string Habitacion { get; set; }
        public string Fecha_Ingreso { get; set; }
        public string Fecha_Salida { get; set; }
    }
}