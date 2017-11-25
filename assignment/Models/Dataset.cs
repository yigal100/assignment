using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace assignment.Models
{
    public class Dataset : DbContext
    {
        private readonly string connectionString;

        public Dataset(DbContextOptions<Dataset> options, IConfiguration configuration) : base(options)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
/*
            modelBuilder.Entity<DeclaringCountry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<PartnerCountry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
*/


            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(r => new { r.Industry, r.EconomicVariable, r.DeclaringCountry, r.PartnerCountry, r.Year});
                entity.Property(e => e).IsRequired();
            });
        }
    }
}
