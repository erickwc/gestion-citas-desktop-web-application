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
        public int IdCita { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdCliente { get; set; }


        [Required(ErrorMessage = "Este cacmpo es requerido")]
        public byte IdEstado { get; set; }


        [Required(ErrorMessage = "Este cacmpo es requerido")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este cacmpo es requerido")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "Este cacmpo es requerido")]
        public TimeSpan TiempoTotal { get; set; }

        [Required(ErrorMessage = "Este cacmpo es requerido")]
        public Decimal PagoTotal { get; set; }

        public int CantidadCitasConfirmadas { get; set; }
        public int CantidadCitasPendientes { get; set; }
        public int CantidadCitasFinalizadas { get; set; }

    }
}
