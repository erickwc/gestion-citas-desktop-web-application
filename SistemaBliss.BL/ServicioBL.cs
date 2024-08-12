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

        public int Eliminar(Servicio pServicio)
        {
            return ServicioDAL.Eliminar(pServicio);
        }

        public static Servicio ObtenerPorId(short pServicio)
        {
           return ServicioDAL.ObtenerPorId(pServicio);
        }
    }
}

