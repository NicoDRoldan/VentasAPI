using Microsoft.EntityFrameworkCore;
using VentasAPI.Models;

namespace VentasAPI.Data
{
    public class MVCVentasContext : DbContext
    {
        public MVCVentasContext(DbContextOptions<MVCVentasContext> options)
            : base(options) { }

        public DbSet<VentasAPI.Models.VMPedidoActual> vMPedidosActuales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VMPedidoActual>()
                .HasKey(pa => new { pa.NumVenta, pa.CodComprobante, pa.CodModulo, pa.NumSucursal, pa.Renglon });

            base.OnModelCreating(modelBuilder);
        }
    }
}
