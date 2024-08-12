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
    public class DepartamentoDAL
    {
        #region Metodos de Busqueda
        public static Departamento ObtenerPorId(byte pIdDepartamento)
        {
            Departamento obj = new Departamento();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerDepartamentoPorId";
            comando.Parameters.AddWithValue("@IdDepartamento", pIdDepartamento);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdDepartamento = reader.GetByte(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }
        #endregion

        public static Departamento ObtenerPorNombre(string pNombreDepartamento)
        {
            Departamento obj = new Departamento();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerDepartamentoPorNombre";
            comando.Parameters.AddWithValue("@Nombre", pNombreDepartamento);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdDepartamento = reader.GetByte(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }
    
    }
}
