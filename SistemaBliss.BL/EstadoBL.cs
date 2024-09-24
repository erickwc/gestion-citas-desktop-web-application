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
        public List<Estado> Buscar(Estado pEstado)
        {
            return EstadoDAL.Buscar(pEstado);
        }

        public List<Estado> BuscarEstadosCitas(Estado pEstado)
        {
            return EstadoDAL.BuscarEstadosCitas(pEstado);
        }

        public List<Estado> BuscarEstadosDetallesCitas(Estado pEstado)
        {
            return EstadoDAL.BuscarEstadosDetallesCitas(pEstado);
        }
    }
}
