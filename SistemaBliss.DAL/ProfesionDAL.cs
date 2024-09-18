using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//REFERENCIAS DEL PROYECTO
using SistemaBliss.EN;
using SistemaElParaisal.DAL;
namespace SistemaBliss.DAL
{
    public class ProfesionDAL
    {
        #region Metodos GUARDAR, MODIFICAR Y ELIMINAR
        public static int Guardar(Profesion pProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", pProfesion.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        public static int Modificar(Profesion pProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProfesion", pProfesion.IdProfesión);
            comando.Parameters.AddWithValue("@Nombre", pProfesion.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        public static Profesion ObtenerPorId(byte pProfesion)
        {
            Profesion obj = new Profesion();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerProfesionPorId";
            comando.Parameters.AddWithValue("@IdProfesion", pProfesion);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdProfesión = reader.GetByte(0); // Columna [0] cero
                obj.Nombre = reader.GetString(1);  // Columna [1] uno
            }
            return obj;
        }
        public static List<Profesion> Buscar(Profesion pProfesion)
        {
            List<Profesion> lista = new List<Profesion>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
              
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdProfesion, Nombre
                            FROM Profesion  ";

                // Validar filtros
                if (pProfesion.Nombre != null && pProfesion.Nombre.Trim() != string.Empty)
                {
                    
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
                    Profesion obj = new Profesion();
                    // Orden de las columnas depende de la Consulta SELECT utilizada
                    obj.IdProfesión = reader.GetByte(0);
                    obj.Nombre = reader.GetString(1);
                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion
            return lista;
        }



        public static List<Profesion> BuscarSinParametro()
        {
            List<Profesion> lista = new List<Profesion>();

            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                string consulta = @"SELECT TOP 100 IdProfesion, Nombre FROM Profesion";

                comando.CommandText = consulta;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Profesion obj = new Profesion
                    {
                        IdProfesión = reader.GetByte(0),
                        Nombre = reader.GetString(1)
                    };
                    lista.Add(obj);
                }
                reader.Close();
            }

            return lista;
        }

    }
}
