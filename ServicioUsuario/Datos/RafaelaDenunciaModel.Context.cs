﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioUsuario.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RafaelaDenunciaEntities : DbContext
    {
        public RafaelaDenunciaEntities()
            : base("name=RafaelaDenunciaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<Denuncias> Denuncias { get; set; }
        public virtual DbSet<Perdidas> Perdidas { get; set; }
        public virtual DbSet<TipoDenuncias> TipoDenuncias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
