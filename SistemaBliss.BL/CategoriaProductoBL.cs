using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class CategoriaProductoBL
    {
        public int Guardar(CategoriaProducto pCategoriaProducto)
        {
            return CategoriaProductoDAL.Guardar(pCategoriaProducto);
        }

        public int Modificar(CategoriaProducto pCategoriaProducto)
        {
            return CategoriaProductoDAL.Modificar(pCategoriaProducto);
        }

        public int ObtenerPorId(CategoriaProducto pIdCategoriaProducto)
        {
            return CategoriaProductoDAL.BuscarPorId(pIdCategoriaProducto);
        }

        public int Buscar(CategoriaProducto pIdCategoriaProducto)
        {
            return CategoriaProductoDAL.Buscar(pIdCategoriaProducto);
        }
    }
}
