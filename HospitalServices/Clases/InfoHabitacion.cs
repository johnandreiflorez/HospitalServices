using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class InfoHabitacion
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Departamento { get; set; }
        public string Piso { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }

    }
}