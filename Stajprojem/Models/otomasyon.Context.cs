﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stajprojem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class otomasyonEntities : DbContext
    {
        public otomasyonEntities()
            : base("name=otomasyonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Missions> Missions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserWorks> UserWorks { get; set; }
        public virtual DbSet<Works> Works { get; set; }
    }
}
