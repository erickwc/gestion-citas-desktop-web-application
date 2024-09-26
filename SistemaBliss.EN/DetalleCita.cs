using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class DetalleCita
    {

        public Int64 IdDetalleCita { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdServicio { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public Int64 IdCita { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdEstado { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public TimeSpan TiempoEstimado{ get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public Decimal Precio { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Empleado { get; set; }
        public string Servicio { get; set; }
        public string Estado { get; set; }
        
    }
}
