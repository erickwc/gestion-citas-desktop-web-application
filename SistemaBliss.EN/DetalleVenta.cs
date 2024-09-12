using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class DetalleVenta
    {
        public long IdDetalleVenta { get; set; }
        public long IdVenta { get; set; }
        public byte IdProducto { get; set; }
        public short Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }

    }
}
