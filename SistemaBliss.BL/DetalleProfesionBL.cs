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
        //public DetalleProfesión ObtenerPorId(short pIdDetalleProfesion)
        //{
        //    return DetalleProfesionDAL.ObtenerPorId(pIdDetalleProfesion);
        //}
        public List<DetalleProfesión> Buscar(int pIdDetalleProfesion)
        {
            return DetalleProfesionDAL.Buscar(pIdDetalleProfesion);
        }
        public static int Guardar(DetalleProfesión pDetalleProfesion)
        {
            return DetalleProfesionDAL.Guardar(pDetalleProfesion);
        }

        public static int Modifiar(DetalleProfesión pDetalleProfesion)
        {
            return DetalleProfesionDAL.Modificar(pDetalleProfesion);
        }

        public static int Eliminar(int pDetalleProfesion)
        {
            return DetalleProfesionDAL.Eliminar(pDetalleProfesion);
        }

        
    }
}
