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
        public static SqlCommand GuardarDetalle(DetalleCita pDetalleCita, SqlTransaction pTransaccion)
        {
            SqlCommand comando = ComunDB.ObtenerComando(pTransaccion);
            comando.CommandText = "SP_InsertarDetalleCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pDetalleCita.IdServicio);
            comando.Parameters.AddWithValue("@IdCita", pDetalleCita.IdCita);
            comando.Parameters.AddWithValue("@IdUsuario", pDetalleCita.IdUsuario);
            comando.Parameters.AddWithValue("@IdEstado", pDetalleCita.IdEstado);
            comando.Parameters.AddWithValue("@TiempoEstimado", pDetalleCita.TiempoEstimado);
            comando.Parameters.AddWithValue("@PrecioUnitario", pDetalleCita.Precio);
            return comando;

        }

        public static int Guardar(DetalleCita pDetalleCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarDetalleCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pDetalleCita.IdServicio);
            comando.Parameters.AddWithValue("@IdCita", pDetalleCita.IdCita);
            comando.Parameters.AddWithValue("@IdUsuario", pDetalleCita.IdUsuario);
            comando.Parameters.AddWithValue("@IdEstado", pDetalleCita.IdEstado);
            comando.Parameters.AddWithValue("@TiempoEstimado", pDetalleCita.TiempoEstimado);
            comando.Parameters.AddWithValue("@PrecioUnitario", pDetalleCita.Precio);
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


        public static int Eliminar(DetalleCita pDetalleCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_EliminarDetalleCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleCita", pDetalleCita.IdDetalleCita);
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

        public static List<DetalleCita> BuscarPorCita(int idCita)
        {
            List<DetalleCita> lista = new List<DetalleCita>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                comando.CommandText = @"
                   SELECT dc.IdDetalleCita, s.Nombre AS ServicioNombre, 
                   u.Nombre + ' ' + u.Apellido AS Empleado, 
                   e.Nombre AS EstadoNombre, 
                   dc.PrecioUnitario, 
                   dc.TiempoEstimado 
                   FROM DetalleCita dc
                   INNER JOIN Servicio s ON s.IdServicio = dc.IdServicio
                   INNER JOIN Cita c ON c.IdCita = dc.IdCita
                   INNER JOIN Usuario u ON u.IdUsuario = dc.IdUsuario
                   INNER JOIN Estado e ON e.IdEstado = dc.IdEstado
                   WHERE c.IdCita = @IdCita";

                comando.Parameters.AddWithValue("@IdCita", idCita);

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    DetalleCita obj = new DetalleCita
                    {
                        IdDetalleCita = reader.GetInt64(0),
                        Servicio = reader.GetString(1),
                        Empleado = reader.GetString(2),
                        Estado = reader.GetString(3),
                        Precio = reader.GetDecimal(4),  
                        TiempoEstimado = reader.GetTimeSpan(5),  
                    };
                    lista.Add(obj);
                }
            }
            #endregion

            return lista;
        }


        public static decimal BuscarTotalPorCita(int idCita)
        {
            decimal totalPrecio = 0;

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                comando.CommandText = @"SELECT SUM(dc.PrecioUnitario) AS TotalPrecioUnitario FROM DetalleCita dc WHERE dc.IdCita = @IdCita";

                comando.Parameters.AddWithValue("@IdCita", idCita);

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                if (reader.Read())
                {
                    // Verifica si el resultado es DBNull antes de obtenerlo
                    totalPrecio = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                }
            }
            #endregion

            return totalPrecio;
        }


        public static TimeSpan BuscarTiempoTotalPorCita(int idCita)
        {
            TimeSpan TiempoEstimado = TimeSpan.Zero; // Inicializar con TimeSpan.Zero

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                comando.CommandText = @"SELECT CAST(DATEADD(SECOND, SUM(DATEDIFF(SECOND, '00:00:00', dc.TiempoEstimado)), '00:00:00') AS TIME) AS TotalTiempoEstimado 
                                FROM DetalleCita dc 
                                WHERE dc.IdCita = @IdCita"; // Añadido espacio

                comando.Parameters.AddWithValue("@IdCita", idCita);

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                if (reader.Read())
                {
                    // Verifica si el resultado es DBNull antes de obtenerlo
                    if (reader.IsDBNull(0))
                    {
                        TiempoEstimado = TimeSpan.Zero; // Si es nulo, asigna TimeSpan.Zero
                    }
                    else
                    {
                        // Obtener el valor como TimeSpan
                        TiempoEstimado = (TimeSpan)reader.GetValue(0);
                    }
                }
            }
            #endregion

            return TiempoEstimado;
        }




        #endregion
    }
}
