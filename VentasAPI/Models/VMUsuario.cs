using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasAPI.Models
{
    public class VMUsuario
    {
        [Key]
        public int Id_Usuario { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }
        public bool Estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public virtual VMCategoria Categoria { get; set; }
    }
}
