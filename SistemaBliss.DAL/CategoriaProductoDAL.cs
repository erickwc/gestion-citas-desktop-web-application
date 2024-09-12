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
    public class CategoriaProductoDAL
    {
        #region METODOS GUARDAR, MODIFICAR
        public static int Guardar(CategoriaProducto pCategoriaProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", pCategoriaProducto.Nombre);
            return ComunDB.EjecutarComando(comando);

        }
        public static int Modificar(CategoriaProducto pCategoriaProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", pCategoriaProducto.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        #region METODOS DE BUSQUEDA
        public static int Buscar(CategoriaProducto pCategoriaProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_BuscarCategoriaProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", pCategoriaProducto.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        public static int BuscarPorId(Producto pCategoriaProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ObtenerCategoriaProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", pCategoriaProducto.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
    }

}

