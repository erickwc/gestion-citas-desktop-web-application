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
    public class MunicipioDAL
    {
        #region Metodos de Busqueda
        public static Municipio ObtenerPorId(Int16 pIdMunicipio)
        {
            Municipio obj = new Municipio();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerMunicipioPorId";
            comando.Parameters.AddWithValue("@IdMunicipio", pIdMunicipio);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdMunicipio = reader.GetInt16(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }
        #endregion

        public static List<Municipio> Buscar(Municipio pMunicipio)
        {
            List<Municipio> lista = new List<Municipio>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"SELECT IdMunicipio, Nombre FROM Municipio WHERE IdDepartamento = @IdDepartamento";

                comando.Parameters.AddWithValue("@IdDepartamento", pMunicipio.IdDepartamento);
                comando.CommandText = consulta;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Municipio obj = new Municipio();
                    obj.IdMunicipio = reader.GetInt16(0);
                    obj.Nombre = reader.GetString(1);

                    lista.Add(obj);
                }
            }

            return lista;
        }


    }
}
