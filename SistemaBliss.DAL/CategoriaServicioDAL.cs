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
    }
}
