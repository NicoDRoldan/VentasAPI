using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VentasAPI.Models
{
    [Table("Articulos")]
    public class VMArticuloOrder
    {
        [Key]
        public int id_Articulo { get; set; }

        public string Nombre { get; set; }
    }
}
