using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBliss.DAL;
using SistemaBliss.EN;

namespace SistemaBliss.BL
{
    public class CategoriaServicioBL
    {
        public List<CategoriaServicio> Buscar(CategoriaServicio pCategoriaServcio)
        {
            return CategoriaServicioDAL.Buscar(pCategoriaServcio);
        }
    }
}
