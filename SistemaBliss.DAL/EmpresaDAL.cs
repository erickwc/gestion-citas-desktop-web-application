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
    public class EmpresaDAL
    {
        #region Metodo MODIFICAR
        public static int Modificar(Empresa pEmpresa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarInformacionEmpresa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdEmpresa", pEmpresa.IdEmpresa);
            comando.Parameters.AddWithValue("@Nombre", pEmpresa.Nombre);
            comando.Parameters.AddWithValue("@Telefono", pEmpresa.Telefono);
            comando.Parameters.AddWithValue("@Direccion", pEmpresa.Direccion);
            comando.Parameters.AddWithValue("@CorreoElectronico", pEmpresa.CorreoElectronico);
            return ComunDB.EjecutarComando(comando);
        }

        #region Metodos de Busqueda
        public static Empresa ObtenerPorId(byte pIdEmpresa)
        {
            Empresa obj = new Empresa();

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ObtenerEmpresaPorId";
            comando.Parameters.AddWithValue("@IdEmpresa", pIdEmpresa);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read())
            {
                obj.IdEmpresa = reader.GetByte(0);
                obj.Nombre = reader.GetString(1);
                obj.Direccion = reader.GetString(2);
                obj.Telefono = reader.GetString(3);
                obj.CorreoElectronico = reader.GetString(4);
            }
            return obj;
        }
        #endregion


        public static List<Empresa> Buscar(Empresa pEmpresa)
        {
            List<Empresa> lista = new List<Empresa>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
             
                string whereSQL = " ";
                string consulta = @"SELECT * FROM Empresa ";

                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    Empresa obj = new Empresa();

                    // Manejar posibles valores nulos y conversiones adecuadas
                    obj.IdEmpresa = reader.GetByte(0);
                    obj.Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    obj.Direccion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    obj.Telefono = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    obj.CorreoElectronico = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

                    lista.Add(obj);
                }
                comando.Connection.Dispose();
            }
            #endregion

            return lista;
        }

        #endregion
    }
}
