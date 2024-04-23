namespace VentasAPI.Models
{
    public class VMOrderGroup
    {
        public int NumPedido { get; set; }

        public string? Retira { get; set; }

        public IEnumerable<VMPedidoActual> DetallePedidos { get; set; }
    }
}
