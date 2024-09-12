using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class DetalleCita
    {
        public Int64 IdDetalleCita { get; set; }
        public byte IdServicio { get; set; }
        public Int64 IdCita { get; set; }
        public int IdUsuario { get; set; }
        public byte IdEstado { get; set; }
    }
}
