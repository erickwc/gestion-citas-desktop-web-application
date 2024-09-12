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
    public class ProductoDAL
    {
        #region METODOS GUARDAR, MODIFICAR
        public static int Guardar(Producto pProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCategoriaProducto", pProducto.IdCategoriaProducto);
            comando.Parameters.AddWithValue("@IdEstado", pProducto.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
            comando.Parameters.AddWithValue("@Precio", pProducto.Precio);
            return ComunDB.EjecutarComando(comando);

        }
        public static int Modificar(Producto pProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCategoriaProducto", pProducto.IdCategoriaProducto);
            comando.Parameters.AddWithValue("@IdEstado", pProducto.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
            comando.Parameters.AddWithValue("@Precio", pProducto.Precio);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
        #region METODOS DE BUSQUEDA
        public static int Buscar(Producto pProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_BuscarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCategoriaProducto", pProducto.IdCategoriaProducto);
            comando.Parameters.AddWithValue("@IdEstado", pProducto.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
            comando.Parameters.AddWithValue("@Precio", pProducto.Precio);
            return ComunDB.EjecutarComando(comando);
        }
        public static int BuscarPorId(Producto pProducto)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ObtenerProductoPorId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCategoriaProducto", pProducto.IdCategoriaProducto);
            comando.Parameters.AddWithValue("@IdEstado", pProducto.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
            comando.Parameters.AddWithValue("@Precio", pProducto.Precio);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion
    }
}
