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

        public static List<HorariosEmpresa> Buscar()
        {
            List<HorariosEmpresa> lista = new List<HorariosEmpresa>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"Select IdHorariosEmpresa, IdEmpresa, Dia, HoraEntrada, HoraSalida from HorariosEmpresa";

                comando.CommandText = consulta;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    HorariosEmpresa obj = new HorariosEmpresa
                    {
                        IdHorariosEmpresa = reader.GetByte(0),
                        IdEmpresa = reader.GetByte(1),
                        Dias = reader.GetString(2),
                        HoraEntrada = reader.GetTimeSpan(3),
                        HoraSalida = reader.GetTimeSpan(4),
                    };

                    lista.Add(obj);
                }
                reader.Close();
            }

            return lista;
        }
    }
}
