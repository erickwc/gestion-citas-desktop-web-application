using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias
using SistemaBliss.EN;
using SistemaBliss.DAL;

namespace SistemaBliss.BL
{
    public class DetalleVentaBL
    {
        public int Guardar(DetalleVenta pdetalleVenta)
        {
            return DetalleVentaDAL.Guardar(pdetalleVenta);
        }

        public int Modificar(DetalleVenta pdetalleVenta)
        {
            return DetalleVentaDAL.Modificar(pdetalleVenta);
        }

        public int ObtenePorId(DetalleVenta pdetalleVenta)
        {
            return DetalleVentaDAL.ObtenerPorId(pdetalleVenta);
        }

    }
}
