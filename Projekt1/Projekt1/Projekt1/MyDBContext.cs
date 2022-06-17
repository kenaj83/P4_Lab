using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Projekt1
{
    internal class MyDBContext:DbContext
    {
        public DbSet<Faktury> Faktury { get; set; }

        public DbSet<Dostawca> Dostawca { get; set; }

        public DbSet<Sprzet> Sprzet { get; set; }

        public DbSet<Osoba> Osoba { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inwentaryzacja;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dostawca>()
                .Property(x => x.NazwaFirmy)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Sprzet>()
                .Property(x => x.NazwaSprzetu)
                .HasColumnType("varchar(50)");

           // modelBuilder.Entity<Sprzet>(sp =>
           //{
           //    sp.Property(x => x.DataPrzekazania).HasDefaultValueSql("getutcdate()");
           //});
        }

    }
}
