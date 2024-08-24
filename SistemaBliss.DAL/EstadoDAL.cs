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
                string consulta = @"SELECT TOP 2 IdEstado, Nombre FROM Estado  ";

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
                    obj.IdEstado = Convert.ToByte(reader.GetValue(0));
                    obj.Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

        // TRATAMIENTO DE DATOS
        public static Dictionary<byte, Estado> ObtenerDiccionario(byte[] pArrayIdEstado)
        {
            List<Estado> lista = new List<Estado>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"SELECT e.IdEstado, e.Nombre
            FROM Estado e
            WHERE e.IdEstado IN (" + string.Join(",", pArrayIdEstado.Select((id, index) => "@Id" + index)) + ")";

                comando.CommandText = consulta;

                // Añadir los parámetros
                for (int i = 0; i < pArrayIdEstado.Length; i++)
                {
                    comando.Parameters.AddWithValue("@Id" + i, pArrayIdEstado[i]);
                }

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Estado obj = new Estado();
                    // Orden de las columnas depende de la Consulta SELECT utilizada
                    obj.IdEstado = reader.GetByte(0); // Asumiendo que IdEstado es de tipo int
                    obj.Nombre = reader.GetString(1);
                    lista.Add(obj);
                }
                comando.Connection.Dispose();

            }

            // El return se puede explicar como: "x" es una instancia de cargo
            // y el metodo debe devolver un diccionario <byte, Cargo>, IdCargo es de tipo byte y Cargo es de tipo Cargo 
            return lista.ToDictionary(x => x.IdEstado, x => x);
        }
    }
}
