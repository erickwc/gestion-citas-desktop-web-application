using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class DepartamentoBL
    {
        public Departamento ObtenerPorId(byte pIdDepartamento)
        {
            return DepartamentoDAL.ObtenerPorId(pIdDepartamento);
        }
        public Departamento ObtenerPorNombre(string pNombreDepartamento)
        {
            return DepartamentoDAL.ObtenerPorNombre(pNombreDepartamento);
        }
    }
}
