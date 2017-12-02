using WebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApi.Data
{
    public class DatasetContext : DbContext
    {
        private readonly string connectionString;

        public DatasetContext(DbContextOptions<DatasetContext> options, IConfiguration configuration) : base(options)
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

            modelBuilder.Entity<DeclaringCountry>(entity => 
            {
                entity.ToTable("declaring_countries");
                entity.Property(p => p.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<EconomicVariable>(entity =>
            {
                entity.ToTable("economic_variables");
                entity.Property(p => p.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("industries");
                entity.Property(p => p.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PartnerCountry>(entity =>
            {
                entity.ToTable("partner_countries");
                entity.Property(p => p.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PowerCode>(entity =>
            {
                entity.ToTable("power_codes");
                entity.Property(p => p.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("units");
                entity.Property(p => p.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("records");
                entity.HasKey(r => new
                {
                    r.IndustryId,
                    r.EconomicVariableId,
                    r.DeclaringCountryId,
                    r.PartnerCountryId,
                    r.Year
                });
                entity.HasIndex(r => r.Year);
            });
        }
    }
}
