﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalServices.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBHospital : DbContext
    {
        public DBHospital()
            : base("name=DBHospital")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Atencion> Atencions { get; set; }
        public virtual DbSet<Enfermera> Enfermeras { get; set; }
        public virtual DbSet<Facturacion> Facturacions { get; set; }
        public virtual DbSet<Habitacion> Habitacions { get; set; }
        public virtual DbSet<Ingreso> Ingresoes { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Tratamiento> Tratamientoes { get; set; }
        public virtual DbSet<Tratamiento_asignado> Tratamiento_asignado { get; set; }
    }
}
