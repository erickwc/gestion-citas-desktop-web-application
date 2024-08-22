using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
   public class DetalleProfesión
    {
        public int IdDetalleProfesion { get; set; }
        public int IdUsuario { get; set; }
        public int IdProfesion { get; set; }
        public string NombreProfesion { get; set; }
        public virtual Usuario Usuario { get; set; }


        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Profesión Profesión { get; set; }


    }
}
