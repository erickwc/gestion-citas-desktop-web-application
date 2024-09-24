using SistemaBliss.EN;
using SistemaElParaisal.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.DAL
{
    public class DetalleCitaDAL
    {
        #region METODOS GUARDAR, MODIFICAR
        public static int Guardar(DetalleCita pDetalleCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarDetalleCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pDetalleCita.IdServicio);
            comando.Parameters.AddWithValue("@IdCita", pDetalleCita.IdCita);
            comando.Parameters.AddWithValue("@IdUsuario", pDetalleCita.IdUsuario);
            comando.Parameters.AddWithValue("@IdEstado", pDetalleCita.IdEstado);
            return ComunDB.EjecutarComando(comando);

        }
        public static int Modificar(DetalleCita pDetalleCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarDetalleCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pDetalleCita.IdServicio);
            comando.Parameters.AddWithValue("@IdCita", pDetalleCita.IdCita);
            comando.Parameters.AddWithValue("@IdUsuario", pDetalleCita.IdUsuario);
            comando.Parameters.AddWithValue("@IdEstado", pDetalleCita.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        #region METODOS DE BUSQUEDA
        public static int BuscarPorId(DetalleCita pDetalleCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ObtenerDetalleCitaPorId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pDetalleCita.IdServicio);
            comando.Parameters.AddWithValue("@IdCita", pDetalleCita.IdCita);
            comando.Parameters.AddWithValue("@IdUsuario", pDetalleCita.IdUsuario);
            comando.Parameters.AddWithValue("@IdEstado", pDetalleCita.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

       
        #endregion
    }
}
