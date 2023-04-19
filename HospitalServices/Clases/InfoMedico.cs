using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class InfoMedico
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int ID_Especializacion { get; set; }

    }
}