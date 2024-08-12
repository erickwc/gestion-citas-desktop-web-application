using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class RolBL
    {
        public Rol ObtenerPorId(byte pIdRol)
        {
            return RolDAL.ObtenerPorId(pIdRol);
        }
        public Rol ObtenerPorNombre(string pNombreRol)
        {
            return RolDAL.ObtenerPorNombre(pNombreRol);
        }
    }
}
