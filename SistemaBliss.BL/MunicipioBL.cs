using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class MunicipioBL
    {
        public Municipio ObtenerPorId(Int16 pIdMunicipio)
        {
            return MunicipioDAL.ObtenerPorId(pIdMunicipio);
        }

        public List<Municipio> Buscar(Municipio pMunicipio)
        {
            return MunicipioDAL.Buscar(pMunicipio);
        }
    }
}
