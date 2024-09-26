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


        public static List<DetalleProfesión> Buscar(int pIdUsuario)
        {
            List<DetalleProfesión> lista = new List<DetalleProfesión>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"
            SELECT 
                P.IdProfesion,
                P.Nombre AS NombreProfesion,
                DP.IdDetalleProfesion
            FROM 
                DetalleProfesion DP
            INNER JOIN 
                Profesion P ON DP.IdProfesion = P.IdProfesion
            WHERE 
                DP.IdUsuario = @IdUsuario";

                // Asignar el parámetro
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@IdUsuario", pIdUsuario);

                // Ejecutar la consulta
                using (SqlDataReader reader = ComunDB.EjecutarComandoReader(comando))
                {
                    while (reader.Read())
                    {
                        DetalleProfesión detalle = new DetalleProfesión()
                        {
                            IdProfesion = Convert.ToInt32(reader["IdProfesion"]),
                            NombreProfesion = reader["NombreProfesion"].ToString(),
                            IdDetalleProfesion = Convert.ToInt32(reader["IdDetalleProfesion"])
                        };
                        lista.Add(detalle);
                    }
                }
            }

            return lista;
        }

        public static List<DetalleProfesión> BuscarProfesionesPorUsuario(int idUsuario)
        {
            List<DetalleProfesión> lista = new List<DetalleProfesión>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                comando.CommandText = @"select dp.IdDetalleProfesion, p.Nombre from DetalleProfesion dp
                INNER JOIN Profesion p ON p.IdProfesion = dp.IdProfesion where IdUsuario = @IdUsuario";

                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    DetalleProfesión obj = new DetalleProfesión
                    {
                        IdDetalleProfesion = reader.GetInt32(0),
                        NombreProfesion = reader.GetString(1),
                    };
                    lista.Add(obj);
                }
            }
            #endregion

            return lista;
        }


    }
}