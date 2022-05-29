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
        public DbSet<OptionEntity> Options { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VoteEntity> Votes { get; set; }
        public DbSet<TokenEntity> Tokens { get; set; }

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

            modelBuilder.Entity<OptionEntity>(entity =>
            {
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.Ci)
                    .HasMaxLength(64);

                entity.Property(e => e.AlreadyVoted)
                    .IsRequired(true);
            });

            modelBuilder.Entity<VoteEntity>(entity =>
            {
                entity.HasOne(v => v.Circuit)
                    .WithMany(c => c.Votes)
                    .HasForeignKey(v => v.CircuitNumber)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(v => v.Option)
                    .WithMany(o => o.Votes)
                    .HasForeignKey(v => v.OptionName)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
