using Central.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.DAL.EFCore.Core
{
    public class CentralContext : DbContext
    {
        readonly IConfiguration _configuration;
        public CentralContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CentralContext(DbContextOptions<CentralContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<DepartmentalVoteEntity> DepartamentalVotes { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<ElectionEntity> Elections { get; set; }
        public DbSet<OptionEntity> Options { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_configuration.GetConnectionString("DbConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentalVoteEntity>(entity =>
            {
                entity.HasKey(dv => new { dv.DepartmentName, dv.OptionName });

                entity.HasOne(dv => dv.Department)
                      .WithMany(d => d.DepartamentalVotes)
                      .HasForeignKey(dv => dv.DepartmentName)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dv => dv.Option)
                      .WithMany(o => o.DepartamentalVotes)
                      .HasForeignKey(dv => dv.OptionName)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OptionEntity>(entity =>
            {
                entity.HasOne(o => o.Election)
                      .WithMany(e => e.Options)
                      .HasForeignKey(o => o.ElectionId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
