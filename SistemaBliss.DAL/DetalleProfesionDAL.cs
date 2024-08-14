using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBliss.EN;
using SistemaElParaisal.DAL;
namespace SistemaBliss.DAL
{
    public class DetalleProfesionDAL
    {
        #region Metodos GUARDAR, MODIFICAR Y ELIMINAR
        public static int Guardar(DetalleProfesión pDetalleProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProfesion", pDetalleProfesion.IdProfesion);
            comando.Parameters.AddWithValue("@Usuario", pDetalleProfesion.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        public static int Modificar(DetalleProfesión pDetalleProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarDetalleProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProfesion", pDetalleProfesion.IdProfesion);
            comando.Parameters.AddWithValue("@Usuario", pDetalleProfesion.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar(DetalleProfesión pDetalleProfesion)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_EliminarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProfesion", pDetalleProfesion.IdDetalleProfesion);
            return ComunDB.EjecutarComando(comando);
        }
        public static DetalleProfesión ObtenerPorId(byte pIdDetalleProfesion)
        {
            DetalleProfesión obj = new DetalleProfesión();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerRolPorId";
            comando.Parameters.AddWithValue("@IdRol", pIdDetalleProfesion);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                // Orden de las columnas depende de la Consulta SELECT utilizada
                obj.IdDetalleProfesion = reader.GetByte(0); // Columna [0] cero
                obj.IdProfesion = reader.GetInt32(1);  // Columna [1] uno
            }
            return obj;
        }

        public static List<DetalleProfesión> Buscar(DetalleProfesión pDetalleProfesion)
        {
            List<DetalleProfesión> lista = new List<DetalleProfesión>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 100 c.IdCargo, c.Nombre
                            FROM Cargo c ";

                // Validar filtros
                if (pDetalleProfesion.Profesión != null && pDetalleProfesion.Profesión.ToString() != string.Empty)
                {
                    if (contador > 0)
                        whereSQL += " AND ";
                    contador += 1;
                    whereSQL += " c.Nombre LIKE @Nombre ";
                    comando.Parameters.AddWithValue("@Nombre", "%" + pDetalleProfesion.Profesión + "%");
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
                    DetalleProfesión obj = new DetalleProfesión();
                    // Orden de las columnas depende de la Consulta SELECT utilizada
                    obj.IdDetalleProfesion = reader.GetByte(0);
                    obj.IdProfesion = reader.GetInt32(1);
                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion
            return lista;
        }

    }
}
