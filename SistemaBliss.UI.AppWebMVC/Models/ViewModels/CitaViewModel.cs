using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBliss.UI.AppWebMVC.Models.ViewModels
{
    public class CitaViewModel
    {
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public TimeSpan TiempoTotal { get; set; }
        public Decimal PagoTotal { get; set; }
    }

    public class Servicios 
    {
        public byte IdServicio { get; set; }
        public int IdUsuario { get; set; }
        public byte IdEstado { get; set; }

    }
}