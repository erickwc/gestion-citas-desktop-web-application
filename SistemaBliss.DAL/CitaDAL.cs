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

        public static List<Usuario> BuscarEmpleadosActivos(Usuario pUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT DISTINCT TOP 100 IdUsuario, IdRol, IdDepartamento, IdEstado, Nombre, Apellido, Telefono, Contrasena, CorreoElectronico, Dui, Direccion, UrlImagen
                            FROM Usuario ";

                // Validar filtros

                if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " Nombre LIKE @Nombre ";
                    comando.Parameters.AddWithValue("@Nombre", "%" + pUsuario.Nombre + "%");
                }
                if (!string.IsNullOrWhiteSpace(pUsuario.Apellido))
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " Apellido LIKE @Apellido ";
                    comando.Parameters.AddWithValue("@Apellido", "%" + pUsuario.Apellido + "%");
                }
                if (!string.IsNullOrWhiteSpace(pUsuario.Telefono))
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " CAST(Telefono AS VARCHAR(8)) LIKE @Telefono ";
                    comando.Parameters.AddWithValue("@Telefono", "%" + pUsuario.Telefono.Trim() + "%");
                }
                if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " IdEstado=1 ";
                }
                if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " IdRol=1 ";
                }
                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }

                comando.CommandText = consulta + whereSQL;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Usuario obj = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),                // 0 -> IdUsuario
                            IdRol = reader.GetByte(1),                     // 1 -> IdRol
                            IdDepartamento = reader.GetByte(2),            // 2 -> IdDepartamento
                            IdEstado = reader.GetByte(3),                  // 3 -> IdEstado
                            Nombre = reader.GetString(4),                  // 4 -> Nombre
                            Apellido = reader.GetString(5),                // 5 -> Apellido
                            Telefono = reader.GetString(6),                // 6 -> Telefono
                            Contrasena = reader.GetString(7),              // 7 -> Contrasena
                            CorreoElectronico = reader.GetString(8),       // 8 -> CorreoElectronico
                            Dui = reader.GetString(9),                     // 9 -> Dui
                            Direccion = reader.GetString(10),              // 10 -> Direccion
                            //UrlImagen = reader.GetString(11)               // 11 -> UrlImagen
                        };

                        // Agregar el objeto Usuario a la lista
                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

    }
}
