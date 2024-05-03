namespace VentasAPI.Models
{
    public class VMVenta
    {
        public string NumVenta { get; set; }

        public string CodComprobante { get; set; }

        public string CodModulo { get; set; }

        public string NumSucursal { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set;}

        public VMFormaPago FormaPago { get; set; }

        public VMCliente Cliente { get; set; }

        public VMUsuario Usuario { get; set; }

        public int NumCaja { get; set; }

        public VMVentaDetalle VentaDetalle { get; set; }

        public VMVentaImporte VentaImpore { get; set; }
    }
}
