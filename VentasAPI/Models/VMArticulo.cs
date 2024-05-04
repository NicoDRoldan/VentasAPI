using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentasAPI.Models
{
    public class VMArticulo
    {
        public int Id_Articulo { get; set; }

        public string Nombre { get; set; }

        public virtual VMRubro Rubro { get; set; }

        public bool Activo { get; set; }

        public string? Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }

        public bool UsaStock { get; set; }

        public bool UsaCombo { get; set; }

    }
}
