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
            if (string.IsNullOrEmpty(pServicio.Imagen))
            {
                comando.Parameters.AddWithValue("@UrlImagen", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@UrlImagen", pServicio.Imagen);
            }
            return ComunDB.EjecutarComando(comando);

        }

        public static int Modificar(Servicio pServicio)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pServicio.IdServicio);
            comando.Parameters.AddWithValue("@IdCategoriaServicio", pServicio.IdCategoriaServicio);
            comando.Parameters.AddWithValue("@IdEstado", pServicio.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pServicio.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", pServicio.Descripción);
            comando.Parameters.AddWithValue("@DiasAnticipacion", pServicio.DiasAnticipacion);
            comando.Parameters.AddWithValue("@Restricciones", pServicio.Restricciones);
            comando.Parameters.AddWithValue("@Precio", pServicio.Precio);
            comando.Parameters.AddWithValue("@Duracion", pServicio.Duracion);
            if (string.IsNullOrEmpty(pServicio.Imagen))
            {
                comando.Parameters.AddWithValue("@UrlImagen", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@UrlImagen", pServicio.Imagen);
            }
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
              
                obj.IdServicio = reader.GetByte(0); 
                obj.IdCategoriaServicio = reader.GetByte(1); // Columna [0] cero
                obj.IdEstado = reader.GetByte(2); //Colummna [1] uno
                obj.Nombre = reader.GetString(3);  // Columna [2] uno
                obj.Descripción = reader.GetString(4); // Columna [3] dos
                obj.DiasAnticipacion = reader.GetByte(5); // Columna [4] cuatro
                obj.Restricciones = reader.GetString(6); // Columna [5] cuatro
                obj.Precio = reader.GetDecimal(7); // Columna [6] cuatro
                obj.Duracion = reader.GetTimeSpan(8); // Columna [7] cuatro
                obj.Imagen = reader.IsDBNull(9) ? null : reader.GetString(9);
            }
            return obj;

        }

        public static List<Servicio> BuscarServiciosActivos(Servicio pServicio)
        {
            List<Servicio> lista = new List<Servicio>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                List<string> condiciones = new List<string>();
                string consulta = @"SELECT TOP 100 IdServicio, IdCategoriaServicio, IdEstado, Nombre, Descripcion, DiasAnticipacion, Restricciones, Precio, Duracion, UrlImagen FROM Servicio WHERE IdEstado = 1";

                // Validar filtros y agregar condiciones
                if (pServicio.IdCategoriaServicio > 0)
                {
                    condiciones.Add("IdCategoriaServicio = @IdCategoriaServicio");
                    comando.Parameters.AddWithValue("@IdCategoriaServicio", pServicio.IdCategoriaServicio);
                }
                if (!string.IsNullOrEmpty(pServicio.Nombre))
                {
                    condiciones.Add("Nombre LIKE @ValorNA");
                    comando.Parameters.AddWithValue("@ValorNA", "%" + pServicio.Nombre + "%");
                }

                // Si hay condiciones adicionales, las agregamos a la consulta
                if (condiciones.Count > 0)
                {
                    consulta += " AND " + string.Join(" AND ", condiciones);
                }

                comando.CommandText = consulta;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Servicio obj = new Servicio();

                    obj.IdServicio = reader.GetByte(0);
                    obj.IdCategoriaServicio = reader.GetByte(1);
                    obj.IdEstado = reader.GetByte(2);
                    obj.Nombre = reader.GetString(3);
                    obj.Descripción = reader.GetString(4);
                    obj.Restricciones = reader.GetString(6);
                    obj.Precio = reader.GetDecimal(7);
                    obj.Duracion = reader.GetTimeSpan(8);
                    obj.Imagen = reader.IsDBNull(9) ? null : reader.GetString(9);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }

            return lista;
        }



        public static List<Servicio> BuscarServiciosInactivos(Servicio pServicio)
        {
            List<Servicio> lista = new List<Servicio>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                List<string> condiciones = new List<string>();
                string consulta = @"SELECT TOP 100 IdServicio, IdCategoriaServicio, IdEstado, Nombre, Descripcion, DiasAnticipacion, Restricciones, Precio, Duracion, UrlImagen FROM Servicio WHERE IdEstado = 2";

                // Validar filtros y agregar condiciones
                if (pServicio.IdCategoriaServicio > 0)
                {
                    condiciones.Add("IdCategoriaServicio = @IdCategoriaServicio");
                    comando.Parameters.AddWithValue("@IdCategoriaServicio", pServicio.IdCategoriaServicio);
                }
                if (!string.IsNullOrEmpty(pServicio.Nombre))
                {
                    condiciones.Add("Nombre LIKE @ValorNA");
                    comando.Parameters.AddWithValue("@ValorNA", "%" + pServicio.Nombre + "%");
                }

                // Si hay condiciones adicionales, las agregamos a la consulta
                if (condiciones.Count > 0)
                {
                    consulta += " AND " + string.Join(" AND ", condiciones);
                }

                comando.CommandText = consulta;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Servicio obj = new Servicio();

                    obj.IdServicio = reader.GetByte(0);
                    obj.IdCategoriaServicio = reader.GetByte(1);
                    obj.IdEstado = reader.GetByte(2);
                    obj.Nombre = reader.GetString(3);
                    obj.Descripción = reader.GetString(4);
                    obj.Restricciones = reader.GetString(6);
                    obj.Precio = reader.GetDecimal(7);
                    obj.Duracion = reader.GetTimeSpan(8);
                    obj.Imagen = reader.IsDBNull(9) ? null : reader.GetString(9);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }

            return lista;
        }





        public static List<Servicio> BuscarServiciosCita(Servicio pServicio)
        {
            List<Servicio> lista = new List<Servicio>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"Select IdServicio, Nombre from Servicio  ";

                comando.CommandText = consulta;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Servicio obj = new Servicio();

                    // Manejar posibles valores nulos y conversiones adecuadas
                    obj.IdServicio = reader.GetByte(0);
                    obj.Nombre = reader.GetString(1);

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