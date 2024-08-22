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
                string consulta = @"SELECT TOP 100 IdRol, Nombre FROM Rol ";

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
                    Rol obj = new Rol();

                    // Manejar posibles valores nulos y conversiones adecuadas
                    obj.IdRol = Convert.ToByte(reader.GetValue(0));
                    obj.Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }



        // TRATAMIENTO DE DATOS
        public static Dictionary<byte, Rol> ObtenerDiccionario(byte[] pArrayIdRol)
        {
            List<Rol> lista = new List<Rol>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"SELECT r.IdRol, r.Nombre
            FROM Rol r
            WHERE r.IdRol IN (" + string.Join(",", pArrayIdRol.Select((id, index) => "@Id" + index)) + ")";

                comando.CommandText = consulta;

                // Añadir los parámetros
                for (int i = 0; i < pArrayIdRol.Length; i++)
                {
                    comando.Parameters.AddWithValue("@Id" + i, pArrayIdRol[i]);
                }

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Rol obj = new Rol();
                    // Orden de las columnas depende de la Consulta SELECT utilizada
                    obj.IdRol = reader.GetByte(0); // Asumiendo que IdEstado es de tipo int
                    obj.Nombre = reader.GetString(1);
                    lista.Add(obj);
                }
                comando.Connection.Dispose();

            }

            // El return se puede explicar como: "x" es una instancia de cargo
            // y el metodo debe devolver un diccionario <byte, Cargo>, IdCargo es de tipo byte y Cargo es de tipo Cargo 
            return lista.ToDictionary(x => x.IdRol, x => x);
        }


    }
}
