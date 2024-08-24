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
        public static int Guardar(Profesión pProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", pProfesion.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        public static int Modificar(Profesión pProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProfesion", pProfesion.IdProfesión);
            comando.Parameters.AddWithValue("@Nombre", pProfesion.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        public static Profesión ObtenerPorId(byte pProfesion)
        {
            Profesión obj = new Profesión();

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
        public static List<Profesión> Buscar(Profesión pProfesion)
        {
            List<Profesión> lista = new List<Profesión>();

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
                    Profesión obj = new Profesión();
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



        public static List<Profesión> BuscarSinParametro()
        {
            List<Profesión> lista = new List<Profesión>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
              
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 IdProfesion, Nombre
                            FROM Profesion  ";

              
                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Profesión obj = new Profesión();
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
    }
}
