using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class DetalleCitaBL
    {
        public int Guardar(DetalleCita pDetalleCita)
        {
            return DetalleCitaDAL.Guardar(pDetalleCita);
        }

        public int Modificar(DetalleCita pDetalleCita)
        {
            return DetalleCitaDAL.Modificar(pDetalleCita);
        }

        public int ObtenerPorId(DetalleCita pIdDetalleCita)
        {
            return DetalleCitaDAL.BuscarPorId(pIdDetalleCita);
        }
    }
}
