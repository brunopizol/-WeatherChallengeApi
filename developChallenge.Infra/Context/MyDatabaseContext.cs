using developChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Infra.Context
{
    public class MyDatabaseContext : DbContext
    {
        #region Constructors
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<City> Cities { get; set; }
        public DbSet<Airport> Airports { get; set; }
        #endregion

        #region Methods



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>(entity =>
            {

                entity.Property(e => e.CodigoIcao)
                      .HasMaxLength(10);
                entity.Property(e => e.Condicao)
                      .HasMaxLength(50);
                entity.Property(e => e.CondicaoDesc)
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<City>(entity =>
            {
                
                entity.HasKey(e => e.Id);        
                entity.Property(e => e.CityName)
                      .HasMaxLength(100);

                entity.Property(e => e.StateCode)
                .HasMaxLength(2);

                entity.HasOne(e => e.Clima)
                      .WithOne(c => c.City)
                      .HasForeignKey<Clima>(c => c.CityId);
            });

           
            modelBuilder.Entity<Clima>(entity =>
            {

                entity.HasKey(e => e.CityId);

                entity.HasOne(e => e.City)
                      .WithOne(c => c.Clima)
                      .HasForeignKey<Clima>(c => c.CityId);
            });

            base.OnModelCreating(modelBuilder);

        }
        #endregion
    }
}

