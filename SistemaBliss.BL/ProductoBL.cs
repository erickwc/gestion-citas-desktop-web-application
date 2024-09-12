using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class ProductoBL
    {
        public int Guardar(Producto pProducto)
        {
            return ProductoDAL.Guardar(pProducto);
        }

        public int Modificar(Producto pProducto)
        {
            return ProductoDAL.Modificar(pProducto);
        }

        public int ObtenerPorId(Producto pIdProducto)
        {
            return ProductoDAL.BuscarPorId(pIdProducto);
        }

        public int Buscar(Producto pIdProducto)
        {
            return ProductoDAL.Buscar(pIdProducto);
        }
    }
}
