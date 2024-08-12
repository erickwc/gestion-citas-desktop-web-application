using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class EstadoBL
    {
        public Estado ObtenerPorId(byte pIdEstado)
        {
            return EstadoDAL.ObtenerPorId(pIdEstado);
        }
        public Estado ObtenerPorNombre(string pNombreEstado)
        {
            return EstadoDAL.ObtenerPorNombre(pNombreEstado);
        }
    }
}
