using challenge.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETChallenge.Models;

namespace NETChallenge.Data
{
    public class ContextDB : DbContext
    {
        public DbSet<Accion> Accion { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<EstadoOrdenDeInversion> EstadoOrdenDeInversion { get; set; }
        public DbSet<OrdenDeInversion> OrdenDeInversion { get; set; }
        public DbSet<OrdenDeInversionOperacion> OrdenDeInversionOperacion { get; set; }
        public DbSet<TipoDeActivo> TipoDeActivo { get; set; }
        public DbSet<TipoOperacionAuditoria> TipoOperacionAuditoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoOrdenDeInversion>()
            .Property(e => e.Id)
            .ValueGeneratedNever();

            modelBuilder.Entity<Accion>().HasData(
                new Accion { Id = 1, Ticker = "AAPL", Nombre = "Apple", PrecioUnitario = 177.97M },
                new Accion { Id = 2, Ticker = "GOOGL", Nombre = "Alphabet Inc", PrecioUnitario = 138.21M },
                new Accion { Id = 3, Ticker = "MSFT", Nombre = "Microsoft", PrecioUnitario = 329.04M },
                new Accion { Id = 4, Ticker = "KO", Nombre = "Coca Cola", PrecioUnitario = 58.3M },
                new Accion { Id = 5, Ticker = "WMT", Nombre = "Walmart", PrecioUnitario = 163.42M }
            );

            modelBuilder.Entity<EstadoOrdenDeInversion>().HasData(
                new EstadoOrdenDeInversion { Id = 0, Descripcion = "En Proceso" },
                new EstadoOrdenDeInversion { Id = 1, Descripcion = "Ejecutada" },
                new EstadoOrdenDeInversion { Id = 3, Descripcion = "Cancelada" }
            );

            modelBuilder.Entity<OrdenDeInversionOperacion>().HasData(
                new OrdenDeInversionOperacion { Id = 1, Identificador = 'C' },
                new OrdenDeInversionOperacion { Id = 2, Identificador = 'V' }
            );

            modelBuilder.Entity<TipoDeActivo>().HasData(
                new TipoDeActivo { Id = 1, Descripcion = "FCI" },
                new TipoDeActivo { Id = 2, Descripcion = "Acción" },
                new TipoDeActivo { Id = 3, Descripcion = "Bono" }
            );

            modelBuilder.Entity<TipoOperacionAuditoria>().HasData(
                new TipoOperacionAuditoria { Id = 1, Descripcion = "Alta" },
                new TipoOperacionAuditoria { Id = 2, Descripcion = "Baja" },
                new TipoOperacionAuditoria { Id = 3, Descripcion = "Modificacion" }
            );
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario { Id = 1, 
                   NombreUsuario = "admin", 
                   Contraseña= "AGecY2IjNhzArzIUZR2ZRSBZv8eFtVrBitRMWZ27zq1YdxyHPp986NyoDPjX+kussQ=="
               }
           );
        }

    }
}
