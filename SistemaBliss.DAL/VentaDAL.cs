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
    public class VentaDAL
    {
        public static int Buscar(Venta pventa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdVenta", pventa.IdVenta);
            comando.Parameters.AddWithValue("@IdUsuario", pventa.IdUsuario);
            comando.Parameters.AddWithValue("@IdCliente", pventa.IdCliente);
            comando.Parameters.AddWithValue("@NoFactura", pventa.NoFactura);
            comando.Parameters.AddWithValue("@Total", pventa.Total);
            comando.Parameters.AddWithValue("@FechaHora", pventa.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Guardar(Venta pventa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_GuardarVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdVenta", pventa.IdVenta);
            comando.Parameters.AddWithValue("@IdUsuario", pventa.IdUsuario);
            comando.Parameters.AddWithValue("@IdCliente", pventa.IdCliente);
            comando.Parameters.AddWithValue("@NoFactura", pventa.NoFactura);
            comando.Parameters.AddWithValue("@Total", pventa.Total);
            comando.Parameters.AddWithValue("@FechaHora", pventa.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(Venta pventa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_Venta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdVenta", pventa.IdVenta);
            comando.Parameters.AddWithValue("@IdUsuario", pventa.IdUsuario);
            comando.Parameters.AddWithValue("@IdCliente", pventa.IdCliente);
            comando.Parameters.AddWithValue("@NoFactura", pventa.NoFactura);
            comando.Parameters.AddWithValue("@Total", pventa.Total);
            comando.Parameters.AddWithValue("@FechaHora", pventa.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
        public static int ObtenerPorId(Venta pventa)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ObtenerIdVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdVenta", pventa.IdVenta);
            comando.Parameters.AddWithValue("@IdUsuario", pventa.IdUsuario);
            comando.Parameters.AddWithValue("@IdCliente", pventa.IdCliente);
            comando.Parameters.AddWithValue("@NoFactura", pventa.NoFactura);
            comando.Parameters.AddWithValue("@Total", pventa.Total);
            comando.Parameters.AddWithValue("@FechaHora", pventa.IdUsuario);
            return ComunDB.EjecutarComando(comando);
        }
    }
}
