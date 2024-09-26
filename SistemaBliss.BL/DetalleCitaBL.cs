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
    public class DetalleCitaBL
    {
        public int Guardar(DetalleCita pDetalleCita)
        {
            return DetalleCitaDAL.GuardarDetalle(pDetalleCita);
        }

        //public int Modificar(DetalleCita pDetalleCita)
        //{
        //    return DetalleCitaDAL.Modificar(pDetalleCita);
        //}

        public int Eliminar(DetalleCita pIdDetalleCita)
        {
            return DetalleCitaDAL.Eliminar(pIdDetalleCita);
        }

        public int ObtenerPorId(DetalleCita pIdDetalleCita)
        {
            return DetalleCitaDAL.BuscarPorId(pIdDetalleCita);
        }

        public List<DetalleCita> BuscarPorCita(int Id)
        {
            return DetalleCitaDAL.BuscarPorCita(Id);
        }

        public decimal BuscarTotalPorCita(int Id)
        {
            return DetalleCitaDAL.BuscarTotalPorCita(Id);
        }

        public TimeSpan BuscarTiempoTotalPorCita(int Id)
        {
            return DetalleCitaDAL.BuscarTiempoTotalPorCita(Id);
        }



    }
}
