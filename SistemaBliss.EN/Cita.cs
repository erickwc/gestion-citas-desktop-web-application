using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Cita
    {

        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public byte IdEstado { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public TimeSpan TiempoTotal { get; set; }
        public Decimal PagoTotal { get; set; }
    }
}
