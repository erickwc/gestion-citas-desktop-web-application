using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBliss.EN;
using SistemaElParaisal.DAL;
namespace SistemaBliss.DAL
{
    public class DetalleProfesionDAL
    {
        #region Metodos GUARDAR, MODIFICAR Y ELIMINAR
        public static int Guardar(DetalleProfesión pDetalleProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarDetalleprofesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProfesion", pDetalleProfesion.IdProfesion);
            comando.Parameters.AddWithValue("@IdUsuario", pDetalleProfesion.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        public static int Modificar(DetalleProfesión pDetalleProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarDetalleProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProfesion", pDetalleProfesion.IdDetalleProfesion);
            comando.Parameters.AddWithValue("@IdProfesion", pDetalleProfesion.IdProfesion);
            comando.Parameters.AddWithValue("@IdUsuario", pDetalleProfesion.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar(DetalleProfesión pDetalleProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_EliminarDetalleProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProfesion", pDetalleProfesion.IdDetalleProfesion);
            return ComunDB.EjecutarComando(comando);
        }
        public static DetalleProfesión ObtenerPorId(Int32 pIdDetalleProfesion)
        {
            DetalleProfesión obj = new DetalleProfesión();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerDetalleProfesionPorId";
            comando.Parameters.AddWithValue("@IdDetalleProfesion", pIdDetalleProfesion);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdDetalleProfesion = reader.GetInt32(0); // Columna [0] cero
                obj.IdUsuario = reader.GetInt32(1);  // Columna [1] uno
                //obj.IdProfesion = reader.GetInt32(2);  // Columna [1] uno
            }
            return obj;
        }

        public static List<DetalleProfesión> Buscar(DetalleProfesión pDetalleProfesion)
        {
            List<DetalleProfesión> lista = new List<DetalleProfesión>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdDetalleProfesion, IdUsuario, IdProfesion
                            FROM DetalleProfesion ";


                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    DetalleProfesión obj = new DetalleProfesión();
                    // Orden de las columnas depende de la Consulta SELECT utilizada
                    obj.IdDetalleProfesion = reader.GetInt32(0);
                    obj.IdUsuario = reader.GetInt32(1);
                    obj.IdProfesion = reader.GetByte(2);
                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion
            return lista;
        }

    }
}