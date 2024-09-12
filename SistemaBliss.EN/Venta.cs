using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Venta
    {
        public long IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public long NoFactura { get; set; }
        public decimal Total {  get; set; }
        public DateTime FechaHora { get; set; }

    }
}
