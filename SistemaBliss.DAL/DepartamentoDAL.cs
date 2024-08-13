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
    public class DepartamentoDAL
    {
        #region Metodos de Busqueda
        public static Departamento ObtenerPorId(byte pIdDepartamento)
        {
            Departamento obj = new Departamento();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerDepartamentoPorId";
            comando.Parameters.AddWithValue("@IdDepartamento", pIdDepartamento);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdDepartamento = reader.GetByte(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }
        #endregion

        public static List<Departamento> Buscar(Departamento pDepartamento)
        {
            List<Departamento> lista = new List<Departamento>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdDepartamento, Nombre
                                    FROM Departamento ";

                // Validar filtros
                if (pDepartamento.Nombre != null && pDepartamento.Nombre.Trim() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    // @ValorNA = Valor Nombre/Apellido
                    whereSQL += " (Nombre LIKE @ValorNA ";
                    comando.Parameters.AddWithValue("@ValorNA", "%" + pDepartamento.Nombre + "%");
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
                    Departamento obj = new Departamento();
                  
                    obj.IdDepartamento = reader.GetInt16(0);
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
