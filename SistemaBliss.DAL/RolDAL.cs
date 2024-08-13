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

        public static List<Rol> Buscar(Rol pRol)
        {
            List<Rol> lista = new List<Rol>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdRol, Nombre
                                    FROM Rol ";

                // Validar filtros
                if (pRol.Nombre != null && pRol.Nombre.Trim() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    // @ValorNA = Valor Nombre/Apellido
                    whereSQL += " (Nombre LIKE @ValorNA ";
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
                    Rol obj = new Rol();

                    obj.IdRol = reader.GetInt16(0);
                    obj.Nombre = reader.GetString(1);
                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }


    }
}
