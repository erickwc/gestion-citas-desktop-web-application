using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class VentaBL
    {
        public int Guardar(Venta pventa)
        {
            return VentaDAL.Guardar(pventa);
        }

        public int Modificar(Venta pventa)
        {
            return VentaDAL.Modificar(pventa);
        }

        public int ObtenePorId(Venta pventa)
        {
            return VentaDAL.ObtenerPorId(pventa);
        }
        public int Buscar(Venta pventa)
        {
            return VentaDAL.Buscar(pventa);
        }
    }
}
