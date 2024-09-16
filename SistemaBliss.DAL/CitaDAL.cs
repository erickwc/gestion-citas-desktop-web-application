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
    public class CitaDAL
    {
        #region METODOS GUARDAR, MODIFICAR
        public static int Guardar(Cita pCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", pCita.IdCliente);
            comando.Parameters.AddWithValue("@IdEstado", pCita.IdEstado);
            comando.Parameters.AddWithValue("@Fecha", pCita.Fecha);
            comando.Parameters.AddWithValue("@Hora", pCita.Hora);
            comando.Parameters.AddWithValue("@TiempoTotal", pCita.TiempoTotal);
            comando.Parameters.AddWithValue("@PagoTotal", pCita.PagoTotal);
            return ComunDB.EjecutarComando(comando);

        }
        public static int Modificar(Cita pCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", pCita.IdCliente);
            comando.Parameters.AddWithValue("@IdEstado", pCita.IdEstado);
            comando.Parameters.AddWithValue("@Fecha", pCita.Fecha);
            comando.Parameters.AddWithValue("@Hora", pCita.Hora);
            comando.Parameters.AddWithValue("@TiempoTotal", pCita.TiempoTotal);
            comando.Parameters.AddWithValue("@PagoTotal", pCita.PagoTotal);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        #region METODOS DE BUSQUEDA
        public static int Buscar(Cita pCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_BuscarCitaCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", pCita.IdCliente);
            comando.Parameters.AddWithValue("@IdEstado", pCita.IdEstado);
            comando.Parameters.AddWithValue("@Fecha", pCita.Fecha);
            comando.Parameters.AddWithValue("@Hora", pCita.Hora);
            comando.Parameters.AddWithValue("@TiempoTotal", pCita.TiempoTotal);
            comando.Parameters.AddWithValue("@PagoTotal", pCita.PagoTotal);
            return ComunDB.EjecutarComando(comando);
        }
        public static int BuscarPorId(Cita pCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ObtenerCitaPorId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", pCita.IdCliente);
            comando.Parameters.AddWithValue("@IdEstado", pCita.IdEstado);
            comando.Parameters.AddWithValue("@Fecha", pCita.Fecha);
            comando.Parameters.AddWithValue("@Hora", pCita.Hora);
            comando.Parameters.AddWithValue("@TiempoTotal", pCita.TiempoTotal);
            comando.Parameters.AddWithValue("@PagoTotal", pCita.PagoTotal);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        public static Cita CantidadCitasConfirmadas()
        {
            Cita obj = new Cita();
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarCita";
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.CantidadCitasConfirmadas = reader.GetInt32(0);

            }
            return obj;

        }
        public static Cita CantidadCitasPendientes()
        {
            Cita obj = new Cita();
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarCita";
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.CantidadCitasPendientes = reader.GetInt32(0);

            }
            return obj;

        }
        public static Cita CantidadCitasFinalizadas()
        {
            Cita obj = new Cita();
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarCita";
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.CantidadCitasFinalizadas = reader.GetInt32(0);

            }
            return obj;

        }

    }
}
