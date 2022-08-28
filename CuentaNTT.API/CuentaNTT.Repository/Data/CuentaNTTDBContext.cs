using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Models;
using System.Reflection;

namespace CuentaNTT.Repository.Data {
    public class CuentaNTTDBContext : DbContext{
        public CuentaNTTDBContext() : base() { }

        public CuentaNTTDBContext(DbContextOptions<CuentaNTTDBContext> options) 
            : base(options) { 
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected void OnConfiguring(DbContextOptionsBuilder optionBuilder) {
            //optionBuilder.UseSqlServer("Conexion", options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Persona>()
                                .HasOne(p => p.Cliente)
                                .WithOne(c => c.Persona);

            modelBuilder.Entity<Cliente>()
                                .HasOne(c => c.Persona)
                                .WithOne(p => p.Cliente);

            modelBuilder.Entity<Cuenta>()
                                .HasOne(cue => cue.Cliente)
                                .WithMany(cli => cli.Cuentas)
                                .HasForeignKey(cue => cue.ClienteId);

            modelBuilder.Entity<Movimiento>()
                                .HasOne(m => m.Cuenta)
                                .WithMany(c => c.Movimientos)
                                .HasForeignKey(m => m.CuentaId);
        }
    }
}
