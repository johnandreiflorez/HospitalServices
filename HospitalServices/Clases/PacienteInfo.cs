using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class PacienteInfo
    {
        public int ID { get; set; }
        public string Nombre{ get; set; }
        public string Apellido { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Teléfono { get; set; }
        public string Dirección { get; set; }
        public string Tipo_Documento { get; set; }
        public string Documento { get; set; }
    }
}