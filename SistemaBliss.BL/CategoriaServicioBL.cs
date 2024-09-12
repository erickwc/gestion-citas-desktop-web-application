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
        public int Buscar (CategoriaServicio pcategoriaServicio)
        {
            return CategoriaServicioDAL.Buscar(pcategoriaServicio);
        }
    }
}
