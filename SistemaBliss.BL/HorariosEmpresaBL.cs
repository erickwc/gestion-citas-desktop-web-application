using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class HorariosEmpresaBL
    {
        public int Guardar(HorariosEmpresa pHorariosEmpresa)
        {
            return HorariosEmpresaDAL.Guardar(pHorariosEmpresa);
        }

        public int Modifiar(HorariosEmpresa pHorariosEmpresa)
        {
            return HorariosEmpresaDAL.Modificar(pHorariosEmpresa);
        }

        public int Eliminar(HorariosEmpresa pHorariosEmpresa)
        {
            return HorariosEmpresaDAL.Eliminar(pHorariosEmpresa);
        }

        public static void ObtenerHorarios(HorariosEmpresa pHorariosEmpresa)
        {
            HorariosEmpresaDAL.ObtenerHorariosEmpresa();
        }
    }
}
