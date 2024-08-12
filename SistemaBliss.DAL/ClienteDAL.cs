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
        public static Cliente ObtenerPorId(byte pIdCliente)
        {
            Cliente obj = new Cliente();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerCargoPorId";
            comando.Parameters.AddWithValue("@IdCargo", pIdCliente);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdCliente = reader.GetByte(0); // Columna [0] cero
                obj.IdUsuario = reader.GetByte(1);  // Columna [1] uno
            }
            return obj;
        }

        public static int Guardar(Cliente pCliente)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdUsuario", pCliente.IdUsuario);
            comando.Parameters.AddWithValue("@ServiviosAcumulados", pCliente.ServiciosAcumulados);
            return ComunDB.EjecutarComando(comando);
        }

        #endregion

    }
}
