using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class EmpresaBL
    {
        public int Modificar(Empresa pEmpresa)
        {
            return EmpresaDAL.Modificar(pEmpresa);
        }

        public Empresa ObtenerPorId(byte pIdEmpresa)
        {
            return EmpresaDAL.ObtenerPorId(pIdEmpresa);
        }

    }
}
