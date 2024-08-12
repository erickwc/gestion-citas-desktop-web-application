using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class UsuarioBL
    {
        private static string CifrarHashSha256(string pTexto)
        {
            // Metodo para cifrar las claves
            byte[] bytes = Encoding.Unicode.GetBytes(pTexto);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        public int Guardar(Usuario pUsuario)
        {
            pUsuario.Contraseña = CifrarHashSha256(pUsuario.Contraseña);
            return UsuarioDAL.Guardar(pUsuario);
        }
        public int Modificar(Usuario pUsuario)
        {
            pUsuario.Contraseña = CifrarHashSha256(pUsuario.Contraseña);
            return UsuarioDAL.Modificar(pUsuario);
        }
        
    }
}
