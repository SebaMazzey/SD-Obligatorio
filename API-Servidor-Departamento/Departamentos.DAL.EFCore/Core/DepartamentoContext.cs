using Departamentos_Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.EntityFrameworkCore.Extensions;

namespace Departamentos.DAL.EFCore.Core
{
    public class DepartamentoContext : DbContext
    {
        readonly IConfiguration _configuration;
        public DepartamentoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DepartamentoContext(DbContextOptions<DepartamentoContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Circuito> Circuitos { get; set; }
        public DbSet<DispositivoHabilitado> DispositivosHabilitados { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_configuration.GetConnectionString("DbConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Circuito>(entity =>
            {
                entity.Property(e => e.Numero)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<DispositivoHabilitado>(entity =>
            {
                entity.HasOne(d => d.Circuito)
                    .WithMany(c => c.DispositivosHabilitados)
                    .HasForeignKey(d => d.Numero_Circuito)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Opcion>(entity =>
            {
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.CI)
                    .HasMaxLength(12);

                entity.Property(e => e.VotoRealizado)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Voto>(entity =>
            {
                entity.HasOne(v => v.Circuito)
                    .WithMany(c => c.Votos)
                    .HasForeignKey(v => v.Numero_Circuito)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(v => v.Opcion)
                    .WithMany(o => o.Votos)
                    .HasForeignKey(v => v.Nombre_Opcion)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
