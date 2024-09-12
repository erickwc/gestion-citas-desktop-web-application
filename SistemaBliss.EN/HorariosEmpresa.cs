using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class HorariosEmpresa
    {
        [Display(Name = "Id")]
        public byte IdHorariosEmpresa { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdEmpresa { get; set; }

        [Display(Name = "Dias")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Dias { get; set; }

        [Display(Name = "Hora de entrada")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public TimeSpan HoraEntrada { get; set; }

        [Display(Name = "Hora de salida")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public TimeSpan HoraSalida { get; set; }


        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Empresa Empresa { get; set; }
    }
}
