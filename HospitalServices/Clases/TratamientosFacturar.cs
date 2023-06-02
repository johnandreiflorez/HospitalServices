using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class TratamientosFacturar
    {
        //public string Medicamento { get; set; }
        public string Tratamiento { get; set; }
        public Decimal Valor { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
    }
}