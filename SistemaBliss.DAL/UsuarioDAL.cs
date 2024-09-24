using SistemaElParaisal.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBliss.EN;

namespace SistemaBliss.DAL
{
    public class UsuarioDAL
    {
        #region Metodos GUARDAR, MODIFICAR Y ELIMINAR
        public static int Guardar(Usuario pUsuario)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdRol", pUsuario.IdRol);
            comando.Parameters.AddWithValue("@IdDepartamento", pUsuario.IdDepartamento);
            comando.Parameters.AddWithValue("@IdMunicipio", pUsuario.IdMunicipio);
            comando.Parameters.AddWithValue("@IdEstado", pUsuario.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            comando.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            comando.Parameters.AddWithValue("@Telefono", pUsuario.Telefono);
            comando.Parameters.AddWithValue("@Contrasena", pUsuario.Contrasena);
            comando.Parameters.AddWithValue("@CorreoElectronico", pUsuario.CorreoElectronico);
            comando.Parameters.AddWithValue("@Dui", pUsuario.Dui);
            comando.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);

            if (string.IsNullOrEmpty(pUsuario.UrlImagen))
            {
                comando.Parameters.AddWithValue("@UrlImagen", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@UrlImagen", pUsuario.UrlImagen);
            }

            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Usuario pUsuario)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdUsuario", pUsuario.IdUsuario);
            comando.Parameters.AddWithValue("@IdRol", pUsuario.IdRol);
            comando.Parameters.AddWithValue("@IdDepartamento", pUsuario.IdDepartamento);
            comando.Parameters.AddWithValue("@IdMunicipio", pUsuario.IdMunicipio);
            comando.Parameters.AddWithValue("@IdEstado", pUsuario.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            comando.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            comando.Parameters.AddWithValue("@Telefono", pUsuario.Telefono);
            //comando.Parameters.AddWithValue("@Contrasena", pUsuario.Contrasena);
            comando.Parameters.AddWithValue("@CorreoElectronico", pUsuario.CorreoElectronico);
            comando.Parameters.AddWithValue("@Dui", pUsuario.Dui);
            comando.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);

            if (string.IsNullOrEmpty(pUsuario.UrlImagen))
            {
                comando.Parameters.AddWithValue("@UrlImagen", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@UrlImagen", pUsuario.UrlImagen);
            }

            return ComunDB.EjecutarComando(comando);
        }

        #endregion
        #region Metodos de Busqueda
        public static Usuario ObtenerPorId(int pIdUsuario)
        {
            Usuario obj = new Usuario();
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerUsuarioPorId";
            comando.Parameters.AddWithValue("@IdUsuario", pIdUsuario);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdUsuario = reader.GetInt32(0);
                obj.IdRol = reader.GetByte(1); // Columna [0] cero
                obj.IdDepartamento = reader.GetByte(2);  // Columna [1] uno
                obj.IdMunicipio = reader.GetInt16(3);
                obj.IdEstado = reader.GetByte(4); // Columna [4] cuatro
                obj.Nombre = reader.GetString(5); // Columna [4] cuatro
                obj.Apellido = reader.GetString(6); // Columna [4] cuatro
                obj.Telefono = reader.GetString(7); // Columna [4] cuatro
                obj.CorreoElectronico = reader.GetString(8); // Columna [4] cuatro
                obj.Dui = reader.GetString(9); // Columna [4] cuatro
                obj.Direccion = reader.GetString(10); // Columna [4] cuatro
                obj.UrlImagen = reader.IsDBNull(11) ? null : reader.GetString(11);
            }
            return obj;
        }

        public static Usuario ObtenerPorIdLogin(string Telefono, string Contrasena)
        {
            Usuario obj = null; // Inicializar como null

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_Login";
            comando.Parameters.AddWithValue("@Telefono", Telefono);
            comando.Parameters.AddWithValue("@Contrasena", Contrasena);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            if (reader.Read()) // Verifica si se encontró un usuario
            {
                obj = new Usuario
                {
                    Telefono = reader.GetString(0),
                    Contrasena = reader.GetString(1)
                };
            }

            return obj;
        }

        public static List<Usuario> BuscarClientesActivos(Usuario pUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = "";
                string consulta = @"SELECT DISTINCT TOP 100 IdUsuario, IdRol, IdDepartamento, IdEstado, Nombre, Apellido, Telefono, Contrasena, CorreoElectronico, Dui, Direccion, UrlImagen
                    FROM Usuario WHERE IdEstado = 1 AND IdRol = 2"; 

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

                if (!string.IsNullOrEmpty(whereSQL))
                {
                    consulta += " AND " + whereSQL;
                }

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Usuario obj = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            IdRol = reader.GetByte(1),
                            IdDepartamento = reader.GetByte(2),
                            IdEstado = reader.GetByte(3),
                            Nombre = reader.GetString(4),
                            Apellido = reader.GetString(5),
                            Telefono = reader.GetString(6),
                            Contrasena = reader.GetString(7),
                            CorreoElectronico = reader.GetString(8),
                            Dui = reader.GetString(9),
                            Direccion = reader.GetString(10),
                            UrlImagen = reader.IsDBNull(11) ? null : reader.GetString(11)
                        };

                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }


        public static List<Usuario> BuscarClientesInactivos(Usuario pUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = "";
                string consulta = @"SELECT DISTINCT TOP 100 IdUsuario, IdRol, IdDepartamento, IdEstado, Nombre, Apellido, Telefono, Contrasena, CorreoElectronico, Dui, Direccion, UrlImagen
                            FROM Usuario WHERE IdEstado = 2 AND IdRol = 2";  // Filtro de estado activo y rol cliente

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

                if (!string.IsNullOrEmpty(whereSQL))
                {
                    consulta += " AND " + whereSQL;
                }

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Usuario obj = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            IdRol = reader.GetByte(1),
                            IdDepartamento = reader.GetByte(2),
                            IdEstado = reader.GetByte(3),
                            Nombre = reader.GetString(4),
                            Apellido = reader.GetString(5),
                            Telefono = reader.GetString(6),
                            Contrasena = reader.GetString(7),
                            CorreoElectronico = reader.GetString(8),
                            Dui = reader.GetString(9),
                            Direccion = reader.GetString(10),
                            UrlImagen = reader.IsDBNull(11) ? null : reader.GetString(11)
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



        public static List<Usuario> BuscarEmpleadosActivos(Usuario pUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = "";
                string consulta = @"SELECT DISTINCT TOP 100 IdUsuario, IdRol, IdDepartamento, IdEstado, Nombre, Apellido, Telefono, Contrasena, CorreoElectronico, Dui, Direccion, UrlImagen
                            FROM Usuario WHERE IdEstado = 1 AND IdRol = 1"; 

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

                if (!string.IsNullOrEmpty(whereSQL))
                {
                    consulta += " AND " + whereSQL;
                }

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Usuario obj = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            IdRol = reader.GetByte(1),
                            IdDepartamento = reader.GetByte(2),
                            IdEstado = reader.GetByte(3),
                            Nombre = reader.GetString(4),
                            Apellido = reader.GetString(5),
                            Telefono = reader.GetString(6),
                            Contrasena = reader.GetString(7),
                            CorreoElectronico = reader.GetString(8),
                            Dui = reader.GetString(9),
                            Direccion = reader.GetString(10),
                            UrlImagen = reader.IsDBNull(11) ? null : reader.GetString(11)
                        };

                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

        public static List<Usuario> BuscarEmpleadosInactivos(Usuario pUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = "";
                string consulta = @"SELECT DISTINCT TOP 100 IdUsuario, IdRol, IdDepartamento, IdEstado, Nombre, Apellido, Telefono, Contrasena, CorreoElectronico, Dui, Direccion, UrlImagen
                            FROM Usuario WHERE IdEstado = 2 AND IdRol = 1";  // Filtro de estado activo y rol cliente

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

                if (!string.IsNullOrEmpty(whereSQL))
                {
                    consulta += " AND " + whereSQL;
                }

                comando.CommandText = consulta;

                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        Usuario obj = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            IdRol = reader.GetByte(1),
                            IdDepartamento = reader.GetByte(2),
                            IdEstado = reader.GetByte(3),
                            Nombre = reader.GetString(4),
                            Apellido = reader.GetString(5),
                            Telefono = reader.GetString(6),
                            Contrasena = reader.GetString(7),
                            CorreoElectronico = reader.GetString(8),
                            Dui = reader.GetString(9),
                            Direccion = reader.GetString(10),
                            UrlImagen = reader.IsDBNull(11) ? null : reader.GetString(11)
                        };

                        lista.Add(obj);
                    }
                }

                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }


        public static Usuario ObtenerUltimoIdUsuario(string pCorreoElectronico)
        {
            Usuario obj = new Usuario();
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerIdUltimoUsuario";
            comando.Parameters.AddWithValue("@CorreoElectronico", pCorreoElectronico);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdUsuario = reader.GetInt32(0);
               
            }
            return obj;
        }


        public static Usuario ContarTotalClientes()
        {
            Usuario obj = new Usuario();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ContarTotalClientes";

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.ClientesTotales = reader.GetInt32(0);
                
            }
            return obj;
        }

        public static Usuario ContarClientesActivos()
        {
            Usuario obj = new Usuario();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ContarClientesActivos";

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.ClientesActivos = reader.GetInt32(0);

            }
            return obj;
        }

        public static Usuario ContarClientesInactivos()
        {
            Usuario obj = new Usuario();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ContarClientesInactivos";

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.ClientesInactivos = reader.GetInt32(0);

            }
            return obj;
        }


        public static Usuario ContarEmpleadosTotal()
        {
            Usuario obj = new Usuario();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ContarTotalEmpleados";

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.EmpleadosTotales = reader.GetInt32(0);

            }
            return obj;
        }

        public static Usuario ContarEmpleadosActivos()
        {
            Usuario obj = new Usuario();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ContarEmpleadosActivos";

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.EmpleadosActivos = reader.GetInt32(0);

            }
            return obj;
        }

        public static Usuario ContarEmpleadosInactivos()
        {
            Usuario obj = new Usuario();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ContarEmpleadosInactivos";

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.EmpleadosInactivos = reader.GetInt32(0);

            }
            return obj;
        }


        public static Usuario ObtenerClavePorTelefono(string telefono)
        {
            Usuario obj = new Usuario();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ObtenerClavePorTelefono";
                comando.Parameters.AddWithValue("@Telefono", telefono);

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    obj.Contrasena = reader.GetString(0);
                    obj.IdUsuario = reader.GetInt32(1);
               
                }
            }
            return obj;
        }

        public static int ActualizarClaveNoCifrada(Usuario pUsuario)
        {
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                comando.CommandText = "SP_ActualizarClaveNoCifrada";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Contrasena", pUsuario.Contrasena);
                comando.Parameters.AddWithValue("@IdUsuario", pUsuario.IdUsuario);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static List<Usuario> BuscarEmpleadosCita(Usuario pUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"select IdUsuario, Nombre + ' ' + Apellido 'Empleados' from Usuario where IdRol = 1 ";

                comando.CommandText = consulta;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Usuario obj = new Usuario();

                    // Manejar posibles valores nulos y conversiones adecuadas
                    obj.IdUsuario = reader.GetInt32(0);
                    obj.Nombre = reader.GetString(1);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

    }
}
