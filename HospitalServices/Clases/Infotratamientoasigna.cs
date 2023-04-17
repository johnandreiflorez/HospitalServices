using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class Infotratamientoasigna
    {
        public int ID_Tratamiento { get; set; }
        public int ID_Ingreso { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
    }
}