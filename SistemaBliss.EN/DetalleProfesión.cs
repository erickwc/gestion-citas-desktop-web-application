using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaBliss.EN
{
   public class DetalleProfesión
    {
        [Display(Name = "Id")]
        public int IdDetalleProfesion { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdUsuario { get; set; }

        [Display(Name = "Profesion")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdProfesion { get; set; }

        [Display(Name = "Profesion")]
        [Required(ErrorMessage = "Este campo es requerido")]

        public string NombreProfesion { get; set; }


        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Profesion Profesión { get; set; }
        public virtual Usuario Usuario { get; set; }


    }
}
