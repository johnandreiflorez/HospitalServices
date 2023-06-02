using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalServices.Models;

namespace HospitalServices.Clases
{
    public class InfoFacturados
    {
        private DBHospital dbHospital = new DBHospital();
        public int ID { get; set; }
        public int IDIngreso { get; set; }
        public string Paciente { get; set; }
        public string Cedula { get; set; }
        public string FechaIngreso { get; set; }
        public string Habitacion { get; set; }
        public Decimal PrecioHabitacion { get; set; }
        public int Dias { get; set; }
        public Decimal ValorTotal { get; set; }
        public string FechaSalida { get; set; }
        public string FechaPago { get; set; }

        public void calcularDias()
        {
            DateTime fechaSalidaM = DateTime.Parse(FechaSalida);
            DateTime fechaIngresoM = DateTime.Parse(FechaIngreso);
            var dias = (fechaSalidaM - fechaIngresoM).ToString(@"dd");
            Dias = int.Parse(dias);
        }

        public void calcularValor()
        {
            Decimal valorM = 0;
            var response = (from ta in dbHospital.Tratamiento_asignado
                            join t in dbHospital.Tratamientoes on ta.ID_Tratamiento equals t.ID
                            //join tm in dbHospital.Medicamento_Tratamiento on t.ID equals tm.ID_Tratamiento
                            //join m in dbHospital.Medicamentoes on tm.ID_Medicamento equals m.ID
                            where ta.ID_Ingreso == IDIngreso
                            select new TratamientosFacturar
                            {
                                //Medicamento = m.Nombre,
                                Tratamiento = t.Nombre + ": " + t.Descripción,
                                Fecha_Fin = ta.Fecha_fin.ToString(),
                                Fecha_Inicio = ta.Fecha_inicio.ToString(),
                                Valor = t.Costo.Value,
                            }).ToList();
            foreach (var item in response)
            {
                valorM += item.Valor;
            }
            calcularDias();
            valorM += (Dias * PrecioHabitacion);
            ValorTotal = valorM;
        }
    }
}