using SistemaBliss.EN;
using SistemaElParaisal.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.DAL
{
    public class EstadoDAL
    {
        public static Estado ObtenerPorId(byte pIdEstado)
        {
            Estado obj = new Estado();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerEstadoPorId";
            comando.Parameters.AddWithValue("@IdEstado", pIdEstado);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdEstado = reader.GetByte(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }

        public static List<Estado> Buscar(Estado pRol)
        {
            List<Estado> lista = new List<Estado>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdEstado, Nombre FROM Estado ";

                // Validar filtros
                if (pRol.Nombre != null && pRol.Nombre.Trim() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " (Nombre LIKE @ValorNA) ";
                    comando.Parameters.AddWithValue("@ValorNA", "%" + pRol.Nombre + "%");
                }
                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Estado obj = new Estado();

                    // Manejar posibles valores nulos y conversiones adecuadas
                    obj.IdEstado = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
                    obj.Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }
    }
}
