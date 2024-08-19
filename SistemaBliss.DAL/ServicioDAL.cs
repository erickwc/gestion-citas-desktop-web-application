using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SistemaBliss.EN;
using SistemaElParaisal.DAL;

namespace SistemaBliss.DAL
{
    public class ServicioDAL

    {
        #region Metodos GUARDAR, MODIFICAR Y ELIMINAR
        public static int Guardar(Servicio pServicio)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCategoriaServicio", pServicio.IdCategoriaServicio);
            comando.Parameters.AddWithValue("@IdEstado", pServicio.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pServicio.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", pServicio.Descripción);
            comando.Parameters.AddWithValue("@DiasAnticipacion", pServicio.DiasAnticipacion);
            comando.Parameters.AddWithValue("@Restricciones", pServicio.Restricciones);
            comando.Parameters.AddWithValue("@Precio", pServicio.Precio);
            comando.Parameters.AddWithValue("@Duracion", pServicio.Duracion);
            comando.Parameters.AddWithValue("@UrlImagen", pServicio.Imagen);
            return ComunDB.EjecutarComando(comando);

        }

        public static int Modificar(Servicio pServicio)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pServicio.IdCategoriaServicio);
            comando.Parameters.AddWithValue("@IdCategoriaServicio", pServicio.IdCategoriaServicio);
            comando.Parameters.AddWithValue("@IdEstado", pServicio.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pServicio.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", pServicio.Descripción);
            comando.Parameters.AddWithValue("@DiasAnticipacion", pServicio.DiasAnticipacion);
            comando.Parameters.AddWithValue("@Restricciones", pServicio.Restricciones);
            comando.Parameters.AddWithValue("@Precio", pServicio.Precio);
            comando.Parameters.AddWithValue("@Duracion", pServicio.Duracion);
            comando.Parameters.AddWithValue("@UrlImagen", pServicio.Imagen);
            return ComunDB.EjecutarComando(comando);
        }

        public static Servicio ObtenerPorId(short pServicio)
        {
            Servicio obj = new Servicio();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerServicioPorId";
            comando.Parameters.AddWithValue("@IdServicio", pServicio);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdServicio = reader.GetByte(0); // Columna [0] cero
                obj.IdCategoriaServicio = reader.GetByte(1); // Columna [0] cero
                obj.IdEstado = reader.GetByte(2); //Colummna [1] uno
                obj.Nombre = reader.GetString(3);  // Columna [2] uno
                obj.Descripción = reader.GetString(4); // Columna [3] dos
                obj.DiasAnticipacion = reader.GetByte(5); // Columna [4] cuatro
                obj.Restricciones = reader.GetString(6); // Columna [5] cuatro
                obj.Precio = reader.GetDecimal(7); // Columna [6] cuatro
                obj.Duracion = reader.GetTimeSpan(8); // Columna [7] cuatro
                //obj.Imagen = reader.GetString(9); // Columna [8] cuatro
            }
            return obj;

        }

        public static List<Servicio> Buscar(Servicio pServicio)
        {
            List<Servicio> lista = new List<Servicio>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdServicio, IdCategoriaServicio, IdEstado, Nombre, Descripcion, DiasAnticipacion, Restricciones, Precio, Duracion FROM Servicio ";

                // Validar filtros
                if (pServicio.IdCategoriaServicio > 0)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " IdCategoriaServicio = @IdCategoriaServicio ";
                    comando.Parameters.AddWithValue("@IdCategoriaServicio", pServicio.IdCategoriaServicio);
                }
                if (pServicio.Nombre != null && pServicio.Nombre.Trim() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " (Nombre LIKE @ValorNA) ";
                    comando.Parameters.AddWithValue("@ValorNA", "%" + pServicio.Nombre + "%");
                }
                if (pServicio.IdEstado > 0)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " IdEstado = @IdEstado ";
                    comando.Parameters.AddWithValue("@IdEstado", pServicio.IdEstado);
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
                    Servicio obj = new Servicio();

                    obj.IdServicio = reader.GetByte(0); // Columna [0] cero
                    obj.IdCategoriaServicio = reader.GetByte(1); // Columna [0] cero
                    obj.IdEstado = reader.GetByte(2); //Colummna [1] uno
                    obj.Nombre = reader.GetString(3);  // Columna [2] uno
                    obj.Descripción = reader.GetString(4); // Columna [3] dos
                                                           //   obj.DiasAnticipacion = reader.GetInt16(5); // Columna [4] cuatro
                    obj.Restricciones = reader.GetString(6); // Columna [5] cuatro
                    obj.Precio = reader.GetDecimal(7); // Columna [6] cuatro
                    obj.Duracion = reader.GetTimeSpan(8); // Columna [7] cuatro
                                                          //  obj.Imagen = reader.GetString(9); // Columna [8] cuatro

                    // Agregar el objeto Servicio a la lista
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