using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int ServiciosAcumulados { get; set; }

        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Usuario Usuario { get; set; }
    }
}
