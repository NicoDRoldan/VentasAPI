using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasAPI.Models
{
    public class VMLocalidad
    {
        public string CodLocalidad { get; set; }

        public string Nombre { get; set; }
    }
}
