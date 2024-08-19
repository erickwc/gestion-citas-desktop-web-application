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
            comando.Parameters.AddWithValue("@UrlImagen", pUsuario.UrlImagen);
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
            comando.Parameters.AddWithValue("@Contrasena", pUsuario.Contrasena);
            comando.Parameters.AddWithValue("@CorreoElectronico", pUsuario.CorreoElectronico);
            comando.Parameters.AddWithValue("@Dui", pUsuario.Dui);
            comando.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);
            comando.Parameters.AddWithValue("@UrlImagen", pUsuario.UrlImagen);
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
                obj.Contrasena = reader.GetString(8); // Columna [4] cuatro
                obj.Dui = reader.GetString(9); // Columna [4] cuatro
                obj.Direccion = reader.GetString(10); // Columna [4] cuatro
            }
            return obj;
        }

        public static List<Usuario> Buscar(Usuario pUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT DISTINCT TOP 100 IdUsuario, IdRol, IdDepartamento, IdMunicipio, IdEstado, Nombre, Apellido, Telefono, Contrasena, Dui, Direccion
                            FROM Usuario ";

                // Validar filtros
                if (pUsuario.Telefono != null && pUsuario.Telefono.Trim() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " Telefono = @Telefono ";
                    comando.Parameters.AddWithValue("@Telefono", pUsuario.Telefono);
                }
                if (pUsuario.Nombre != null && pUsuario.Nombre.Trim() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " (Nombre LIKE @ValorNA OR Apellido LIKE @ValorNA) ";
                    comando.Parameters.AddWithValue("@ValorNA", "%" + pUsuario.Nombre + "%");
                }
                if (pUsuario.Dui != null && pUsuario.Dui.Trim() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " Dui = @Dui ";
                    comando.Parameters.AddWithValue("@Dui", pUsuario.Dui);
                }
                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Usuario obj = new Usuario();

                    obj.IdUsuario = reader.GetInt32(0);
                    obj.IdRol = reader.GetByte(1);
                    obj.IdDepartamento = reader.GetByte(2);
                    // obj.IdMunicipio = reader.GetByte(3);
                    obj.IdEstado = reader.GetByte(4);
                    obj.Nombre = reader.GetString(5);
                    obj.Apellido = reader.GetString(6);
                    obj.Telefono = reader.GetString(7);
                    obj.Contrasena = reader.GetString(8);
                    obj.Dui = reader.GetString(9);
                    obj.Direccion = reader.GetString(10);

                    // Agregar el objeto Usuario a la lista
                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

        #endregion
    }
}
