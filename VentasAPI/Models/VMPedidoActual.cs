using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VentasAPI.Models
{
    [Table("PedidosActuales")]
    public class VMPedidoActual
    {
        public int NumPedido { get; set; }

        [ForeignKey("NumVenta, CodComprobante, CodModulo, NumSucursal")]
        public string NumVenta { get; set; }

        [Key]
        public string CodComprobante { get; set; }

        [Key]
        public string CodModulo { get; set; }

        [Key]
        public string NumSucursal { get; set; }

        [Key]
        public int Renglon { get; set; }

        [JsonIgnore]
        public int Id_Articulo { get; set; }

        // Propiedad de navegación para articulos:

        [ForeignKey("Id_Articulo")]
        public virtual VMArticuloOrder Articulo { get; set; }
        //public virtual VMArticleGroup Articulos { get; set; }

        public decimal Cantidad { get; set; }

        public string? Retira { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaExpiracion { get; set; }
    }
}
