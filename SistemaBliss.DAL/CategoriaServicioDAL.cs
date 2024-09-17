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
        public static List<Servicio> Buscar(Estado pRol)
        {
            List<Servicio> lista = new List<Servicio>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdCategoriaServicio, Nombre FROM CategoriaServicio  ";

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
    }
}
