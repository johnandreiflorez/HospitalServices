using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class InfoTratamientoAsignado
    {
        public int ID { get; set; }
        public string Paciente { get; set; }
        public string Tratamiento { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
    }
}