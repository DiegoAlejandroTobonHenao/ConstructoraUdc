﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructoraUdcModel.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConstructoraUdcDBEntities : DbContext
    {
        public ConstructoraUdcDBEntities()
            : base("name=ConstructoraUdcDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PMT_City> PMT_City { get; set; }
        public virtual DbSet<PMT_Country> PMT_Country { get; set; }
        public virtual DbSet<SEC_Role> SEC_Role { get; set; }
        public virtual DbSet<SEC_Session> SEC_Session { get; set; }
        public virtual DbSet<SEC_User> SEC_User { get; set; }
        public virtual DbSet<SEC_User_Role> SEC_User_Role { get; set; }
    }
}