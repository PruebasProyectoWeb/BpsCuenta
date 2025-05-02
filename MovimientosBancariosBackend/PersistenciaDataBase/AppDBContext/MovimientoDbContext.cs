using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovimientosEntities.Entities;

namespace PersistenciaDataBase.AppDBContext
{
    public class MovimientoDbContext : DbContext
    {
        public MovimientoDbContext(DbContextOptions<MovimientoDbContext> options) : base(options) { }

        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la tabla Cuenta
            modelBuilder.Entity<Cuenta>()
                .HasKey(c => c.IdCuenta);

            modelBuilder.Entity<Cuenta>()
                .HasIndex(c => c.NumeroCuenta)
                .IsUnique();

            modelBuilder.Entity<Cuenta>()
                .Property(c => c.NumeroCuenta)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Cuenta>()
                .Property(c => c.NombreTitular)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Cuenta>()
                .Property(c => c.Saldo)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0.00m);

            modelBuilder.Entity<Cuenta>()
                .Property(c => c.EstadoCuenta)
                .HasMaxLength(20)
                .HasDefaultValue("Activa")
                .IsRequired();

            modelBuilder.Entity<Cuenta>()
                .Property(c => c.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            // Configuración de la tabla Transaccion
            modelBuilder.Entity<Transaccion>()
                .HasKey(t => t.IdTransaccion);

            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.CuentaOrigen)
                .WithMany()
                .HasForeignKey(t => t.IdCuentaOrigen);

            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.CuentaDestino)
                .WithMany()
                .HasForeignKey(t => t.IdCuentaDestino);

            modelBuilder.Entity<Transaccion>()
                .Property(t => t.Monto)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Transaccion>()
                .Property(t => t.Fecha)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Transaccion>()
                .Property(t => t.TipoTransaccion)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Transaccion>()
                .Property(t => t.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Exitosa")
                .IsRequired();

            // Configuración de la tabla Movimiento
            modelBuilder.Entity<Movimiento>()
                .HasKey(m => m.IdMovimiento);

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Cuenta)
                .WithMany()
                .HasForeignKey(m => m.IdCuenta);

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Transaccion)
                .WithMany()
                .HasForeignKey(m => m.IdTransaccion);

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Monto)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Fecha)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
        }



    }
}
