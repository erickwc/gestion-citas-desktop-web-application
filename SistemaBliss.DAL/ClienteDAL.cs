
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
    public class ClienteDAL
    {
        #region Metodos de Busqueda
        public static Cliente ObtenerPorId(int pIdCliente)
        {
            Cliente obj = new Cliente();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerClientePorId";
            comando.Parameters.AddWithValue("@IdUsuario", pIdCliente);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdCliente = reader.GetInt32(0); // Columna [0] cero
                obj.IdUsuario = reader.GetInt32(1);  // Columna [1] uno
                obj.ServiciosAcumulados = reader.GetInt32(2);  // Columna [1] uno
            }
            return obj;
        }

        public static int Guardar(Cliente pCliente)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdUsuario", pCliente.IdUsuario);
            comando.Parameters.AddWithValue("@ServiciosAcumulados", pCliente.ServiciosAcumulados);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<Cliente> Buscar(Cliente pCliente)
        {
            List<Cliente> lista = new List<Cliente>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdCliente, IdUsuario, ServiciosAcumulados FROM Cliente ";

                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Cliente obj = new Cliente();

                    obj.IdCliente = reader.GetInt32(0); // Columna [0] cero
                    obj.IdUsuario = reader.GetInt32(1);  // Columna [1] uno
                    obj.ServiciosAcumulados = reader.GetInt32(2);  // Columna [1] uno

                    // Agregar el objeto Usuario a la lista
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