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

        public static HorariosEmpresa ObtenerHorariosEmpresa()
        {
            HorariosEmpresa obj = new HorariosEmpresa();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerHorariosEmpresa";

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                obj.IdHorariosEmpresa = reader.GetByte(0); 
                obj.IdEmpresa = reader.GetByte(1); 
                obj.Dias = reader.GetString(1);  
                obj.HoraEntrada = reader.GetTimeSpan(1);
                obj.HoraSalida = reader.GetTimeSpan(1);  
            }
            return obj;
        }
    }
}
