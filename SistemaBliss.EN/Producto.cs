using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Producto
    {
        public byte IdProducto { get; set; }
        public byte IdCategoriaProducto { get; set; }
        public byte IdEstado { get; set; }
        public string Nombre { get; set; }
        public Decimal Precio { get; set; }
    }
}
