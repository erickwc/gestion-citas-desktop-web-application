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
        #region Metodos GUARDAR, MODIFICAR Y ELIMINAR
        public static int Buscar(CategoriaServicio pcategoriaServicio)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarCategoriaServicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCategoriaServicio", pcategoriaServicio.IdCategoriaServicio);
            comando.Parameters.AddWithValue("@IdNombre", pcategoriaServicio.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
    }
}
