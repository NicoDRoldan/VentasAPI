namespace VentasAPI.Models
{
    public class VMVentaDetalle
    {
        public int Renglon { get; set; }

        public VMArticulo Articulo { get; set; }

        public decimal Cantidad { get; set; }

        public string Detalle { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal PrecioTotal { get; set; }
    }
}
