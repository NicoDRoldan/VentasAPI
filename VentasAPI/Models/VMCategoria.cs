﻿using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasAPI.Models
{
    public class VMCategoria
    {
        public int Id_Categoria { get; set; }

        public string Nombre { get; set; }
    }
}
