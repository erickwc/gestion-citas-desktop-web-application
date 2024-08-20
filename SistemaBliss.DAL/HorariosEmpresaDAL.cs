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
    public class HorariosEmpresaDAL
    {
        public static int Guardar(HorariosEmpresa pHorariosEmpresa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarHorariosEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdEmpresa", pHorariosEmpresa.IdEmpresa);
            comando.Parameters.AddWithValue("@Dia", pHorariosEmpresa.Dias);
            comando.Parameters.AddWithValue("@HoraEntrada", pHorariosEmpresa.HoraEntrada);
            comando.Parameters.AddWithValue("@HoraSalida", pHorariosEmpresa.HoraSalida);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(HorariosEmpresa pHorariosEmpresa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarHorariosEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdHorariosEmpresa", pHorariosEmpresa.IdHorariosEmpresa);
            comando.Parameters.AddWithValue("@IdEmpresa", pHorariosEmpresa.IdEmpresa);
            comando.Parameters.AddWithValue("@Dia", pHorariosEmpresa.Dias);
            comando.Parameters.AddWithValue("@HoraEntrada", pHorariosEmpresa.HoraEntrada);
            comando.Parameters.AddWithValue("@HoraSalida", pHorariosEmpresa.HoraSalida);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(HorariosEmpresa pHorariosEmpresa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_EliminarHorariosEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdHorariosEmpresa", pHorariosEmpresa.IdHorariosEmpresa);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<HorariosEmpresa> Buscar(HorariosEmpresa pHorariosEmpresa)
        {
            List<HorariosEmpresa> lista = new List<HorariosEmpresa>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT * FROM HorariosEmpresa ";

                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    HorariosEmpresa obj = new HorariosEmpresa();
                    // Manejar posibles valores nulos y conversiones adecuadas
                    obj.IdHorariosEmpresa = reader.GetByte(0);
                    obj.IdEmpresa = reader.GetByte(1);
                    obj.Dias = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    obj.HoraEntrada = reader.GetTimeSpan(3);
                    obj.HoraSalida = reader.GetTimeSpan(4);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }
    }
}
