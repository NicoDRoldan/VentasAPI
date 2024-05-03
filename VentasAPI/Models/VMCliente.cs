using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentasAPI.Models
{
    public class VMCliente
    {
        public string CodCliente { get; set; }

        public string CUIT { get; set; }

        public string RazonSocial { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string Direccion { get; set; }

        public VMProvincia Provincia { get; set; }

        public VMLocalidad Localidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaAlta { get; set; }
    }
}
