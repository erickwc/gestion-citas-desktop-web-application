using SistemaBliss.DAL;
using SistemaBliss.EN;
using SistemaElParaisal.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<Empresa> Buscar(Empresa pEmpresa)
        {
            return EmpresaDAL.Buscar(pEmpresa);
        }

    }
}
