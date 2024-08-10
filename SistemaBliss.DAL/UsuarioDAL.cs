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
    public class UsuarioDAL
    {
        #region Metodos GUARDAR, MODIFICAR Y ELIMINAR
        public static int Guardar(Usuario pUsuario)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdRol", pUsuario.IdRol);
            comando.Parameters.AddWithValue("@IdDepartamento", pUsuario.IdDepartamento);
            comando.Parameters.AddWithValue("@IdMunicipio", pUsuario.IdMunicipio);
            comando.Parameters.AddWithValue("@IdEstado", pUsuario.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            comando.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            comando.Parameters.AddWithValue("@Telefono", pUsuario.Telefono);
            comando.Parameters.AddWithValue("@Contraseña", pUsuario.Contraseña);
            comando.Parameters.AddWithValue("@CorreoElectronico", pUsuario.CorreoElectronico);
            comando.Parameters.AddWithValue("@Dui", pUsuario.Dui);
            comando.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);
            comando.Parameters.AddWithValue("@UrlImagen", pUsuario.UrlImagen);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Usuario pUsuario)
        {
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = "SP_ModificarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdUsuario", pUsuario.IdUsuario);
            comando.Parameters.AddWithValue("@IdRol", pUsuario.IdRol);
            comando.Parameters.AddWithValue("@IdDepartamento", pUsuario.IdDepartamento);
            comando.Parameters.AddWithValue("@IdMunicipio", pUsuario.IdMunicipio);
            comando.Parameters.AddWithValue("@IdEstado", pUsuario.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            comando.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            comando.Parameters.AddWithValue("@Telefono", pUsuario.Telefono);
            comando.Parameters.AddWithValue("@Contraseña", pUsuario.Contraseña);
            comando.Parameters.AddWithValue("@CorreoElectronico", pUsuario.CorreoElectronico);
            comando.Parameters.AddWithValue("@Dui", pUsuario.Dui);
            comando.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);
            comando.Parameters.AddWithValue("@UrlImagen", pUsuario.UrlImagen);
            return ComunDB.EjecutarComando(comando);
        }
        #endregion

        
    }
}
