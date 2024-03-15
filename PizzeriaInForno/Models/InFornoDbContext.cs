using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using PizzeriaInForno7.Models;
using System.Data.Entity.Infrastructure;

namespace PizzeriaInForno.Models
{
    public class InFornoDbContext
    {
        public object Articoli { get; internal set; }
        public object Utenti { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public partial class InFornoDbContext : DbContext, IEquatable<InFornoDbContext>
        {
            public InFornoDbContext()
                : base("name=InFornoContext")
            {
            }

            public virtual DbSet<Amministratori> Amministratori { get; set; }
            public virtual DbSet<Articoli> Articoli { get; set; }
            public virtual DbSet<DettagliOrdine> DettagliOrdine { get; set; }
            public virtual DbSet<Ordini> Ordini { get; set; }
            public virtual DbSet<OrdiniArticoli> OrdiniArticoli { get; set; }
            public virtual DbSet<Utenti> Utenti { get; set; }

            public override bool Equals(object obj)
            {
                return Equals(obj as InFornoDbContext);
            }

            public bool Equals(InFornoDbContext other)
            {
                return !(other is null) &&
                       base.Equals(other) &&
                       EqualityComparer<Database>.Default.Equals(Database, other.Database) &&
                       EqualityComparer<DbChangeTracker>.Default.Equals(ChangeTracker, other.ChangeTracker) &&
                       EqualityComparer<DbContextConfiguration>.Default.Equals(Configuration, other.Configuration) &&
                       EqualityComparer<DbSet<Amministratori>>.Default.Equals(Amministratori, other.Amministratori) &&
                       EqualityComparer<DbSet<Articoli>>.Default.Equals(Articoli, other.Articoli) &&
                       EqualityComparer<DbSet<DettagliOrdine>>.Default.Equals(DettagliOrdine, other.DettagliOrdine) &&
                       EqualityComparer<DbSet<Ordini>>.Default.Equals(Ordini, other.Ordini) &&
                       EqualityComparer<DbSet<OrdiniArticoli>>.Default.Equals(OrdiniArticoli, other.OrdiniArticoli) &&
                       EqualityComparer<DbSet<Utenti>>.Default.Equals(Utenti, other.Utenti);
            }

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