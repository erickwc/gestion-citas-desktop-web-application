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

    }                                                           
}
