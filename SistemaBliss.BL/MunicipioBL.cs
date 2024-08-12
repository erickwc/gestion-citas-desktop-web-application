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
        public Municipio ObtenerPorId(byte pIdMunicipio)
        {
            return MunicipioDAL.ObtenerPorId(pIdMunicipio);
        }
        public Municipio ObtenerPorNombre(string pNombreMunicipio)
        {
            return MunicipioDAL.ObtenerPorNombre(pNombreMunicipio);
        }
    }
}
