﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalDenuncia.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBDenunciaEntities : DbContext
    {
        public DBDenunciaEntities()
            : base("name=DBDenunciaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBCOMISARIA> TBCOMISARIAS { get; set; }
        public virtual DbSet<TBDELEGADO> TBDELEGADOS { get; set; }
        public virtual DbSet<TBDENUNCIA> TBDENUNCIAS { get; set; }
        public virtual DbSet<TBDISTRITO> TBDISTRITOS { get; set; }
        public virtual DbSet<TBESTADO> TBESTADOS { get; set; }
        public virtual DbSet<TBPOLICIA> TBPOLICIAS { get; set; }
        public virtual DbSet<TBTIPODENUNCIA> TBTIPODENUNCIAS { get; set; }
        public virtual DbSet<TBTIPODOCUMan> TBTIPODOCUMEN { get; set; }
        public virtual DbSet<TBUSUARIO> TBUSUARIOS { get; set; }
        public virtual DbSet<TBVERAZIDAD> TBVERAZIDADs { get; set; }
    }
}
