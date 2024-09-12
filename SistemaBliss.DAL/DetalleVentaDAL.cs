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
    public class DetalleVentaDAL
    {
        public static int Guardar(DetalleVenta pdetalleVenta)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarDetalleVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleVenta", pdetalleVenta.IdDetalleVenta);
            comando.Parameters.AddWithValue("@IdVenta", pdetalleVenta.IdVenta);
            comando.Parameters.AddWithValue("@IdProducto", pdetalleVenta.IdProducto);
            comando.Parameters.AddWithValue("@Cantidad", pdetalleVenta.Cantidad);
            comando.Parameters.AddWithValue("@PrecioUnitario", pdetalleVenta.PrecioUnitario);
            comando.Parameters.AddWithValue("@Subtotal", pdetalleVenta.SubTotal);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(DetalleVenta pdetalleVenta)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarDetalleProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleVenta", pdetalleVenta.IdDetalleVenta);
            comando.Parameters.AddWithValue("@IdVenta", pdetalleVenta.IdVenta);
            comando.Parameters.AddWithValue("@IdProducto", pdetalleVenta.IdProducto);
            comando.Parameters.AddWithValue("@Cantidad", pdetalleVenta.Cantidad);
            comando.Parameters.AddWithValue("@PrecioUnitario", pdetalleVenta.PrecioUnitario);
            comando.Parameters.AddWithValue("@Subtotal", pdetalleVenta.SubTotal);
            return ComunDB.EjecutarComando(comando);
        }
        public static int ObtenerPorId(DetalleVenta pdetalleVenta)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ObtenerIdDetalleProfesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleVenta", pdetalleVenta.IdDetalleVenta);
            comando.Parameters.AddWithValue("@IdVenta", pdetalleVenta.IdVenta);
            comando.Parameters.AddWithValue("@IdProducto", pdetalleVenta.IdProducto);
            comando.Parameters.AddWithValue("@Cantidad", pdetalleVenta.Cantidad);
            comando.Parameters.AddWithValue("@PrecioUnitario", pdetalleVenta.PrecioUnitario);
            comando.Parameters.AddWithValue("@Subtotal", pdetalleVenta.SubTotal);
            return ComunDB.EjecutarComando(comando);
        }

    }
}
