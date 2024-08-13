using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SistemaBliss.BL;
using SistemaBliss.EN;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class UsuarioUnitTest
    {
       UsuarioBL usuarioBL = new UsuarioBL();

        [TestMethod]
        public void T1_Guardar()
        {
            // instancia de Empleado con los datos a guardar
            Usuario usuario = new Usuario();
            usuario.IdRol = 1;
            usuario.IdDepartamento = 1;
            usuario.IdMunicipio = 1;
            usuario.IdEstado = 1;
            usuario.Nombre = "Erick";
            usuario.Apellido = "Caceres";
            usuario.Telefono = "45788881";
            usuario.Contrasena = "123";
            usuario.CorreoElectronico = "erck@gmail.com";
            usuario.Dui = "123456789";
            usuario.Direccion = "Nahuizalco";
            usuario.UrlImagen = "urldelafoto";
            // Ejecutar metodo 
            int resultado = usuarioBL.Guardar(usuario);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se guardo correctamente
            Assert.AreEqual(1, resultado);
        }
    }
}
