using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;

namespace PizzeriaInForno.Models
{
    public class InFornoDbContext
    {
        public partial class InFornoDbContext : DbContext
        {
            public InFornoDbContext()
                : base("name=InFornoDbContext")
            {
            }

            public virtual DbSet<Amministratori> Amministratori { get; set; }
            public virtual DbSet<Articoli> Articoli { get; set; }
            public virtual DbSet<DettagliOrdine> DettagliOrdine { get; set; }
            public virtual DbSet<Ordini> Ordini { get; set; }
            public virtual DbSet<OrdiniArticoli> OrdiniArticoli { get; set; }
            public virtual DbSet<Utenti> Utenti { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Articoli>()
                    .Property(e => e.Prezzo)
                    .HasPrecision(10, 2);

                modelBuilder.Entity<Articoli>()
                    .HasMany(e => e.OrdiniArticoli)
                    .WithOptional(e => e.Articoli)
                    .HasForeignKey(e => e.IDArticolo);

                modelBuilder.Entity<Ordini>()
                    .Property(e => e.Totale)
                    .HasPrecision(10, 2);

                modelBuilder.Entity<Ordini>()
                    .HasMany(e => e.DettagliOrdine)
                    .WithOptional(e => e.Ordini)
                    .HasForeignKey(e => e.IDOrdine);

                modelBuilder.Entity<Ordini>()
                    .HasMany(e => e.OrdiniArticoli)
                    .WithOptional(e => e.Ordini)
                    .HasForeignKey(e => e.IDOrdine);

                modelBuilder.Entity<Utenti>()
                    .HasMany(e => e.Ordini)
                    .WithOptional(e => e.Utenti)
                    .HasForeignKey(e => e.IDUtente);
            }
        }
    }
}