using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referrencias del proyecto 
using SistemaBliss.EN;
using SistemaBliss.DAL;
using SistemaElParaisal.DAL;
using System.Data.SqlClient;
using System.Data;

namespace SistemaBliss.DAL
{
    public class CategoriaServicioDAL
    {
        public static List<CategoriaServicio> Buscar(CategoriaServicio pCategoriaServicio)
        {
            List<CategoriaServicio> lista = new List<CategoriaServicio>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdCategoriaServicio, Nombre FROM CategoriaServicio  ";

                
                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    CategoriaServicio obj = new CategoriaServicio();

                    // Manejar posibles valores nulos y conversiones adecuadas
                    obj.IdCategoriaServicio = Convert.ToByte(reader.GetValue(0));
                    obj.Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }


        public static Dictionary<byte, CategoriaServicio> ObtenerDiccionario(byte[] pArrayIdCategoriaServicio)
        {
            List<CategoriaServicio> lista = new List<CategoriaServicio>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"SELECT e.IdCategoriaServicio, e.Nombre
            FROM CategoriaServicio e
            WHERE e.IdCategoriaServicio IN (" + string.Join(",", pArrayIdCategoriaServicio.Select((id, index) => "@Id" + index)) + ")";

                comando.CommandText = consulta;

                // Añadir los parámetros
                for (int i = 0; i < pArrayIdCategoriaServicio.Length; i++)
                {
                    comando.Parameters.AddWithValue("@Id" + i, pArrayIdCategoriaServicio[i]);
                }

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    CategoriaServicio obj = new CategoriaServicio();
                    // Orden de las columnas depende de la Consulta SELECT utilizada
                    obj.IdCategoriaServicio = reader.GetByte(0); // Asumiendo que IdEstado es de tipo int
                    obj.Nombre = reader.GetString(1);
                    lista.Add(obj);
                }
                comando.Connection.Dispose();

            }

            // El return se puede explicar como: "x" es una instancia de cargo
            // y el metodo debe devolver un diccionario <byte, Cargo>, IdCargo es de tipo byte y Cargo es de tipo Cargo 
            return lista.ToDictionary(x => x.IdCategoriaServicio, x => x);
        }
    }
}
