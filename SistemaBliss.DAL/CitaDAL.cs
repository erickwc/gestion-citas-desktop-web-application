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
            SqlTransaction transaccion = ComunDB.CrearTransaction();

            try
            {
                SqlCommand comando = ComunDB.ObtenerComando(transaccion);
                comando.CommandText = "SP_InsertarCita";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", pCita.IdUsuario);
                comando.Parameters.AddWithValue("@IdEstado", pCita.IdEstado);
                comando.Parameters.AddWithValue("@Fecha", pCita.Fecha);
                comando.Parameters.AddWithValue("@Hora", pCita.Hora);
                comando.Parameters.AddWithValue("@TiempoTotal", pCita.TiempoTotal);
                comando.Parameters.AddWithValue("@PagoTotal", pCita.PagoTotal);

                long idCita = Convert.ToInt64(comando.ExecuteScalar());

                foreach (var detalle in pCita.DetallesCita)
                {
                    // detalle: representa al producto que se agrego a la venta
                    detalle.IdCita = idCita;
                    SqlCommand comandoDetalle = DetalleCitaDAL.GuardarDetalle(detalle, transaccion);

                    // Confirmar Guardar detalle de la venta
                    comandoDetalle.ExecuteNonQuery();
                }

                transaccion.Commit();

       
            }
            catch (Exception ex)
            {
                // Revertir cambios en la DB
                transaccion.Rollback();
                return 0;
            }
            finally
            {
                transaccion.Dispose();
            }

            return 1;
        }

        //public static int Guardar(Cita pCita)
        //{
        //    SqlCommand comando = ComunDB.ObtenerComando();
        //    comando.CommandText = "SP_InsertarCita";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@IdUsuario", pCita.IdUsuario);
        //    comando.Parameters.AddWithValue("@IdEstado", pCita.IdEstado);
        //    comando.Parameters.AddWithValue("@Fecha", pCita.Fecha);
        //    comando.Parameters.AddWithValue("@Hora", pCita.Hora);
        //    comando.Parameters.AddWithValue("@TiempoTotal", pCita.TiempoTotal);
        //    comando.Parameters.AddWithValue("@PagoTotal", pCita.PagoTotal);
        //    return ComunDB.EjecutarComando(comando);
        //}

        public static int Modificar(Cita pCita)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCita", pCita.IdCita);
            comando.Parameters.AddWithValue("@IdUsuario", pCita.IdUsuario);
            comando.Parameters.AddWithValue("@IdEstado", pCita.IdEstado);
            comando.Parameters.AddWithValue("@Fecha", pCita.Fecha);
            comando.Parameters.AddWithValue("@Hora", pCita.Hora);
            comando.Parameters.AddWithValue("@TiempoTotal", pCita.TiempoTotal);
            comando.Parameters.AddWithValue("@PagoTotal", pCita.PagoTotal);
            return ComunDB.EjecutarComando(comando);
        }

        public static Cita ObtenerPorId(int IdCita)
        {
            Cita obj = new Cita();
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerCitaPorId";
            comando.Parameters.AddWithValue("@IdCita", IdCita);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                obj.IdCita = reader.GetInt64(0);
                obj.IdUsuario = reader.GetInt32(1);
                obj.IdEstado = reader.GetByte(2);
                obj.Fecha = reader.GetDateTime(3);
                obj.Hora = reader.GetTimeSpan(4);
                obj.TiempoTotal = reader.GetTimeSpan(5);
                obj.PagoTotal = reader.GetDecimal(6);
            }
            return obj;
        }

        #endregion
        #region METODOS DE BUSQUEDA

        public static List<Cita> BuscarCitasPendientes(Cita pCita, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            List<Cita> lista = new List<Cita>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string whereSQL = " WHERE c.IdEstado = 3";  // Condición inicial para IdEstado

                // Agregamos los filtros de fecha si se proporcionan
                if (fechaInicio.HasValue)
                {
                    whereSQL += " AND c.Fecha >= @FechaInicio";
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value);
                }

                if (fechaFin.HasValue)
                {
                    whereSQL += " AND c.Fecha <= @FechaFin";
                    comando.Parameters.AddWithValue("@FechaFin", fechaFin.Value);
                }

                string consulta = $@"SELECT DISTINCT TOP 100 c.IdCita, c.IdUsuario, u.Nombre + ' ' + u.Apellido AS 'Cliente', 
                             c.IdEstado, c.Fecha, c.Hora, c.TiempoTotal, c.PagoTotal 
                             FROM Cita c 
                             INNER JOIN Usuario u ON u.IdUsuario = c.IdUsuario 
                             {whereSQL};";  // Se inserta la cláusula WHERE con los filtros

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Cita obj = new Cita
                        {
                            IdCita = reader.GetInt64(0), // Cambiado a GetInt64
                            IdUsuario = reader.GetInt32(1),
                            Cliente = reader.GetString(2),
                            IdEstado = reader.GetByte(3),
                            Fecha = reader.GetDateTime(4),
                            Hora = !reader.IsDBNull(5) ? reader.GetTimeSpan(5) : TimeSpan.Zero,
                            TiempoTotal = !reader.IsDBNull(6) ? reader.GetTimeSpan(6) : TimeSpan.Zero,
                            PagoTotal = !reader.IsDBNull(7) ? reader.GetDecimal(7) : 0m,
                        };

                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

        public static List<Cita> BuscarCitasConfirmadas(Cita pCita, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            List<Cita> lista = new List<Cita>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string whereSQL = " WHERE c.IdEstado = 4";  // Condición inicial para IdEstado

                // Agregamos los filtros de fecha si se proporcionan
                if (fechaInicio.HasValue)
                {
                    whereSQL += " AND c.Fecha >= @FechaInicio";
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value);
                }

                if (fechaFin.HasValue)
                {
                    whereSQL += " AND c.Fecha <= @FechaFin";
                    comando.Parameters.AddWithValue("@FechaFin", fechaFin.Value);
                }

                string consulta = $@"SELECT DISTINCT TOP 100 c.IdCita, c.IdUsuario, u.Nombre + ' ' + u.Apellido AS 'Cliente', 
                             c.IdEstado, CAST(c.Fecha AS DATE) AS Fecha, c.Hora, c.TiempoTotal, c.PagoTotal 
                             FROM Cita c 
                             INNER JOIN Usuario u ON u.IdUsuario = c.IdUsuario 
                             {whereSQL};";  // Se inserta la cláusula WHERE con los filtros

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Cita obj = new Cita
                        {
                            IdCita = reader.GetInt64(0), // Cambiado a GetInt64
                            IdUsuario = reader.GetInt32(1),
                            Cliente = reader.GetString(2),
                            IdEstado = reader.GetByte(3),
                            Fecha = reader.GetDateTime(4),
                            Hora = !reader.IsDBNull(5) ? reader.GetTimeSpan(5) : TimeSpan.Zero,
                            TiempoTotal = !reader.IsDBNull(6) ? reader.GetTimeSpan(6) : TimeSpan.Zero,
                            PagoTotal = !reader.IsDBNull(7) ? reader.GetDecimal(7) : 0m,
                        };

                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

        public static List<Cita> BuscarCitasFinalizadas(Cita pCita, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            List<Cita> lista = new List<Cita>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string whereSQL = " WHERE c.IdEstado = 5";  // Condición inicial para IdEstado

                // Agregamos los filtros de fecha si se proporcionan
                if (fechaInicio.HasValue)
                {
                    whereSQL += " AND c.Fecha >= @FechaInicio";
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value);
                }

                if (fechaFin.HasValue)
                {
                    whereSQL += " AND c.Fecha <= @FechaFin";
                    comando.Parameters.AddWithValue("@FechaFin", fechaFin.Value);
                }

                string consulta = $@"SELECT DISTINCT TOP 100 c.IdCita, c.IdUsuario, u.Nombre + ' ' + u.Apellido AS 'Cliente', 
                             c.IdEstado, CAST(c.Fecha AS DATE) AS Fecha, c.Hora, c.TiempoTotal, c.PagoTotal 
                             FROM Cita c 
                             INNER JOIN Usuario u ON u.IdUsuario = c.IdUsuario 
                             {whereSQL};";  // Se inserta la cláusula WHERE con los filtros

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Cita obj = new Cita
                        {
                            IdCita = reader.GetInt64(0), // Cambiado a GetInt64
                            IdUsuario = reader.GetInt32(1),
                            Cliente = reader.GetString(2),
                            IdEstado = reader.GetByte(3),
                            Fecha = reader.GetDateTime(4),
                            Hora = !reader.IsDBNull(5) ? reader.GetTimeSpan(5) : TimeSpan.Zero,
                            TiempoTotal = !reader.IsDBNull(6) ? reader.GetTimeSpan(6) : TimeSpan.Zero,
                            PagoTotal = !reader.IsDBNull(7) ? reader.GetDecimal(7) : 0m,
                        };

                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

        public static List<Cita> BuscarClientes(Cita pCita)
        {
            List<Cita> lista = new List<Cita>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @" select top 100 IdUsuario, Nombre + ' ' + Apellido 'Cliente' from Usuario where IdRol = 2";  // Filtro de estado activo y rol cliente

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Cita obj = new Cita
                        {
                            IdUsuario = reader.GetInt32(0),
                            Cliente = reader.GetString(1),
                        };

                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }


        #endregion


    }
}
