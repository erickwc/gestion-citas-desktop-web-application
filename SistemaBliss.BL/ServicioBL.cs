using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class ServicioBL
    {

        public int Guardar(Servicio pServicio)
        {
            return ServicioDAL.Guardar(pServicio);
        }

        public int Modificar(Servicio pServicio)
        {
            return ServicioDAL.Modificar(pServicio);
        }

        public Servicio ObtenerPorId(short pIdServicio)
        {
            return ServicioDAL.ObtenerPorId(pIdServicio);
        }

        public List<Servicio> Buscar(Servicio pServicio)
        {
            return ServicioDAL.Buscar(pServicio);
        }

    }
}