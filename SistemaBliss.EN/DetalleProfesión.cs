using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
   public class DetalleProfesión
    {
        public int IdDetalleProfesion
        { get; set; }

        public int IdUsuario
        { get; set; }

        public int IdProfesion
        { get; set; }

        public virtual Usuario Usuario
        { get; set; }

        public virtual Profesión Profesión { get; set; }


    }
}
