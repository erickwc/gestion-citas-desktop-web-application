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
            comando.Parameters.AddWithValue("@Imagen", pServicio.Imagen);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Servicio pServicio)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCategoriaServicio", pServicio.IdCategoriaServicio);
            comando.Parameters.AddWithValue("@IdEstado", pServicio.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pServicio.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", pServicio.Descripción);
            comando.Parameters.AddWithValue("@DiasAnticipacion", pServicio.DiasAnticipacion);
            comando.Parameters.AddWithValue("@Restricciones", pServicio.Restricciones);
            comando.Parameters.AddWithValue("@Precio", pServicio.Precio);
            comando.Parameters.AddWithValue("@Duracion", pServicio.Duracion);
            comando.Parameters.AddWithValue("@Imagen", pServicio.Imagen);
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
                obj.DiasAnticipacion = reader.GetInt16(5); // Columna [4] cuatro
                obj.Restricciones = reader.GetString(6); // Columna [5] cuatro
                obj.Precio = reader.GetDecimal(7); // Columna [6] cuatro
                obj.Duracion = reader.GetDateTime(8); // Columna [7] cuatro
                obj.Imagen = reader.GetByte(9); // Columna [8] cuatro
            }
            return obj;

        }
        public static int Eliminar(Servicio pServicio)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_EliminarServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pServicio.IdServicio);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion

    }


}