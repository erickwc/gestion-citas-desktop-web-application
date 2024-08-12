using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias 
using SistemaBliss.EN;
using SistemaBliss.DAL;

namespace SistemaBliss.BL
{
    public class DetalleProfesionBL
    {
        public DetalleProfesión ObtenerPorId(byte pIdDetalleProfesion)
        {
            return DetalleProfesionDAL.ObtenerPorId(pIdDetalleProfesion);
        }
        public List<DetalleProfesión> Buscar(DetalleProfesión pDetalleProfesion)
        {
            return DetalleProfesionDAL.Buscar(pDetalleProfesion);
        }
    }
}
