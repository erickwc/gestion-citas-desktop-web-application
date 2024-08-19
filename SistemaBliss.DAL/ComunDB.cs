using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias
using System.Data;
using System.Data.SqlClient;

namespace SistemaElParaisal.DAL
{
    public class ComunDB
    {
        const string strConexion = @"Data Source=M20-CIII; Initial Catalog=BlissBD;Integrated Security=True;Encrypt=False";

        private static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(strConexion);
            conexion.Open();
            return conexion;
        }

        public static SqlCommand ObtenerComando()
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObtenerConexion();
            return comando;
        }

        public static SqlCommand ObtenerComando(SqlTransaction pTransaction)
        {
            // Sobre carga del metodo ObtenerComando para crear comandos de transaccion
            SqlCommand comando = new SqlCommand();
            comando.Connection = pTransaction.Connection;
            comando.Transaction = pTransaction;
            return comando;
        }

        public static int EjecutarComando(SqlCommand pComando)
        {
            int resultado = pComando.ExecuteNonQuery();
            pComando.Connection.Close();
            return resultado;
        }

        public static SqlDataReader EjecutarComandoReader(SqlCommand pComando)
        {
            SqlDataReader reader = pComando.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public static SqlTransaction CrearTransaction()
        {
            SqlConnection conexion = ObtenerConexion();
            return conexion.BeginTransaction();
        }
    }
}
