using Departments_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.EntityFrameworkCore.Extensions;

namespace Departments.DAL.EFCore.Core
{
    public class DepartmentContext : DbContext
    {
        readonly IConfiguration _configuration;
        public DepartmentContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DepartmentContext(DbContextOptions<DepartmentContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<CircuitEntity> Circuits { get; set; }
        public DbSet<EnabledDeviceEntity> EnabledDevices { get; set; }
        public DbSet<OptionEntity> Options { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<VoteEntity> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_configuration.GetConnectionString("DbConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CircuitEntity>(entity =>
            {
                entity.Property(e => e.Number)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<EnabledDeviceEntity>(entity =>
            {
                entity.HasOne(d => d.Circuit)
                    .WithMany(c => c.EnabledDevices)
                    .HasForeignKey(d => d.Circuit_Number)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OptionEntity>(entity =>
            {
            });

            modelBuilder.Entity<PersonEntity>(entity =>
            {
                entity.Property(e => e.Ci)
                    .HasMaxLength(64);

                entity.Property(e => e.Already_Voted)
                    .IsRequired(true);
            });

            modelBuilder.Entity<VoteEntity>(entity =>
            {
                entity.HasOne(v => v.Circuit)
                    .WithMany(c => c.Votes)
                    .HasForeignKey(v => v.Circuit_Number)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(v => v.Option)
                    .WithMany(o => o.Votes)
                    .HasForeignKey(v => v.Option_Name)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
