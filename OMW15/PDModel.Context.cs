﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMW15
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PDEF : DbContext
    {
        public PDEF()
            : base("name=PDEF")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PRODUCTGROUP> PRODUCTGROUPS { get; set; }
        public virtual DbSet<PRODUCTIONSTDITEM> PRODUCTIONSTDITEMS { get; set; }
        public virtual DbSet<PRDPROCESS> PRDPROCESSes { get; set; }
        public virtual DbSet<PRODUCTIONJOB> PRODUCTIONJOBS { get; set; }
        public virtual DbSet<PRODUCTIONJOBINFO> PRODUCTIONJOBINFOes { get; set; }
        public virtual DbSet<MCBOM> MCBOMs { get; set; }
    }
}
