using System.ComponentModel.DataAnnotations;

namespace VentasAPI.Models
{
    public class VMConcepto
    {
        public string CodConcepto { get; set; }

        public string Descripcion { get; set; }

        [DataType(DataType.Currency)]
        public decimal Porcentaje { get; set; }
    }
}
