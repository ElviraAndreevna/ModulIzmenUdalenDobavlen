﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModulUdalIzmenDobav
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModulEntities2 : DbContext
    {
        public ModulEntities2()
            : base("name=ModulEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<Dogovor> Dogovor { get; set; }
        public virtual DbSet<Obekt_nedvizhimosti> Obekt_nedvizhimosti { get; set; }
        public virtual DbSet<Sotrudnik> Sotrudnik { get; set; }
        public virtual DbSet<Status_dogovora> Status_dogovora { get; set; }
        public virtual DbSet<Status_ob_ekta_nedvizhimosti> Status_ob_ekta_nedvizhimosti { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tip_dogovora> Tip_dogovora { get; set; }
        public virtual DbSet<Tip_nedvizhimosti> Tip_nedvizhimosti { get; set; }
        public virtual DbSet<Vladelec> Vladelec { get; set; }
    }
}
