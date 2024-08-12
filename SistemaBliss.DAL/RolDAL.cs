using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias del proyecto
using SistemaBliss.EN;


using SistemaElParaisal.DAL;

namespace SistemaBliss.DAL
{
    public class RolDAL
    {
        public static Rol ObtenerPorId(byte pIdRol)
        {
            Rol obj = new Rol();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerRolPorId";
            comando.Parameters.AddWithValue("@IdRol", pIdRol);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdRol = reader.GetByte(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }

        public static Rol ObtenerPorNombre(string pNombreRol)
        {
            Rol obj = new Rol();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerRolPorNombre";
            comando.Parameters.AddWithValue("@Nombre", pNombreRol);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdRol = reader.GetByte(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }


    }
}
