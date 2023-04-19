using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class InfoAtencion
    {

        public int ID { get; set; }
        public string Medico { get; set; }
        public string Enfermera { get; set; }
        public string Paciente { get; set; }
        public string Ingreso { get; set; }
        public string Fecha { get; set; }
        public string Notas { get; set; }



    }
}