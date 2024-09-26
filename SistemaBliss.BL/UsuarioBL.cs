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
            pUsuario.Contrasena = CifrarHashSha256(pUsuario.Contrasena);
            return UsuarioDAL.Guardar(pUsuario);
        }
        public int Modificar(Usuario pUsuario)
        {
            //pUsuario.Contrasena = CifrarHashSha256(pUsuario.Contrasena);
            return UsuarioDAL.Modificar(pUsuario);
        }

        public Usuario ObtenerPorId(int pIdUsuario)
        {
            return UsuarioDAL.ObtenerPorId(pIdUsuario);
        }

        public Usuario ObtenerPorIdLogin(string Telefono, string Contrasena)
        {
            return UsuarioDAL.ObtenerPorIdLogin(Telefono, Contrasena);
        }

        public Usuario ContarTotalClientes()
        {
            return UsuarioDAL.ContarTotalClientes();
        }

        public Usuario ContarClientesActivos()
        {
            return UsuarioDAL.ContarClientesActivos();
        }

        public Usuario ContarClientesInactivos()
        {
            return UsuarioDAL.ContarClientesInactivos();
        }

        public Usuario ContarEmpleadosTotales()
        {
            return UsuarioDAL.ContarEmpleadosTotal();
        }

        public Usuario ContarEmpleadosActivos()
        {
            return UsuarioDAL.ContarEmpleadosActivos();
        }

        public Usuario ContarEmpleadosInactivos()
        {
            return UsuarioDAL.ContarEmpleadosInactivos();
        }

        public Usuario ObtenerUltimoIdUsuario(string pCorreoElectronico)
        {
            return UsuarioDAL.ObtenerUltimoIdUsuario(pCorreoElectronico);
        }
        public List<Usuario> BuscarClientesActivos(Usuario pUsuario)
        {
            return UsuarioDAL.BuscarClientesActivos(pUsuario);
        }

        public List<Usuario> BuscarClientesInctivos(Usuario pUsuario)
        {
            return UsuarioDAL.BuscarClientesInactivos(pUsuario);
        }



        public List<Usuario> BuscarEmpleadosActivos(Usuario pUsuario)
        {
            return UsuarioDAL.BuscarEmpleadosActivos(pUsuario);
        }

        public List<Usuario> BuscarEmpleadosInactivos(Usuario pUsuario)
        {
            return UsuarioDAL.BuscarEmpleadosInactivos(pUsuario);
        }

        public List<Usuario> BuscarEmpleadosCita(Usuario pUsuario)
        {
            return UsuarioDAL.BuscarEmpleadosCita(pUsuario);
        }

        public void CargarEstadoVirtual(List<Usuario> pLista, Action<List<Estado>> pAccion = null)
        {
            // Método para cargar los datos de la propiedad virtual de Cargo
            if (pLista.Count > 0)
            {
                // Obtener array de ids de estado de la lista de usuarios
                byte[] arrayIdEstado = pLista.Select(x => x.IdEstado).Distinct().ToArray();

                // Crear Diccionario de Estados buscando en la base de datos
                Dictionary<byte, Estado> diccionario = EstadoDAL.ObtenerDiccionario(arrayIdEstado);



                // Bucle para validar los Cargos e inyectarlo a los Empleados en su propiedad virtual
                foreach (var item in pLista)
                {
                    // Verificar si existe el Cargo en el diccionario
                    if (diccionario.ContainsKey(item.IdEstado) == true)
                    {
                        // Si existe, inyectar el Cargo desde el diccionario
                        item.Estado = diccionario[item.IdEstado];
                    }
                }

                // Accion auxiliar para sobrecargar otra propiedad virtual dentro de la clase Cargo
                if (pAccion != null && diccionario.Count > 0)
                {
                    pAccion(diccionario.Select(x => x.Value).ToList());
                }
            }
        }


        public void CargarRolVirtual(List<Usuario> pLista, Action<List<Rol>> pAccion = null)
        {
            // Método para cargar los datos de la propiedad virtual de Cargo
            if (pLista.Count > 0)
            {
                // Obtener array de ids de estado de la lista de usuarios
                byte[] arrayIdRol = pLista.Select(x => x.IdRol).Distinct().ToArray();

                // Crear Diccionario de Estados buscando en la base de datos
                Dictionary<byte, Rol> diccionario = RolDAL.ObtenerDiccionario(arrayIdRol);



                // Bucle para validar los Cargos e inyectarlo a los Empleados en su propiedad virtual
                foreach (var item in pLista)
                {
                    // Verificar si existe el Cargo en el diccionario
                    if (diccionario.ContainsKey(item.IdRol) == true)
                    {
                        // Si existe, inyectar el Cargo desde el diccionario
                        item.Rol = diccionario[item.IdRol];
                    }
                }

                // Accion auxiliar para sobrecargar otra propiedad virtual dentro de la clase Cargo
                if (pAccion != null && diccionario.Count > 0)
                {
                    pAccion(diccionario.Select(x => x.Value).ToList());
                }
            }
        }

        public Usuario ObtenerClavePorTelefono(string telefono)
        {
            return UsuarioDAL.ObtenerClavePorTelefono(telefono);
        }


        public int ActualizarClaveNoCifrada(Usuario pUsuario)
        {
            pUsuario.Contrasena = CifrarHashSha256(pUsuario.Contrasena);
            return UsuarioDAL.ActualizarClaveNoCifrada(pUsuario);
        }

        public bool EsContraseñaCifrada(string contrasena)
        {
            // Verifica si la longitud es igual a 64 caracteres hexadecimales (para SHA-256)
            return contrasena.Length == 64;
        }

        public Usuario AutenticarCredenciales(Usuario pUsuario)
        {
            pUsuario.Contrasena = CifrarHashSha256(pUsuario.Contrasena);
            return UsuarioDAL.AutenticarCredenciales(pUsuario);
        }


    }
}
