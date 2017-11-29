using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using assignment.Models;

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
        public DbSet<EconomicVariable> EconomicVariables { get; set; }
        public DbSet<Industry> Industry { get; set; }
        public DbSet<DeclaringCountry> DeclaringCountry { get; set; }
        public DbSet<PartnerCountry> PartnerCountry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(r => new {
                    r.IndustryId,
                    r.EconomicVariableId,
                    r.DeclaringCountryId,
                    r.PartnerCountryId,
                    r.Year,
                    r.QuantityId});
            });
        }
    }
}
