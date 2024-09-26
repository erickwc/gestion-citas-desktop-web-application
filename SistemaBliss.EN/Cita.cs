using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaBliss.EN
{
    public class Cita
    {
        [Display(Name = "Id")]
        public long IdCita { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdUsuario { get; set; }
        public string Cliente { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdEstado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public TimeSpan Hora { get; set; }

        //[Required(ErrorMessage = "Este campo es requerido")]
        public TimeSpan TiempoTotal { get; set; }

        //[Required(ErrorMessage = "Este campo es requerido")]
        public Decimal PagoTotal { get; set; }

        public List<DetalleCita> DetallesCita { get; set; }

        public int CantidadCitasConfirmadas { get; set; }
        public int CantidadCitasPendientes { get; set; }
        public int CantidadCitasFinalizadas { get; set; }

    }
}
