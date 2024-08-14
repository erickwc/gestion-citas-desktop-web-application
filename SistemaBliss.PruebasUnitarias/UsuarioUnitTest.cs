using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System.Collections.Generic;

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

        [TestMethod]
        public void T2_Modificar()
        {
            // instancia de Empleado con los datos a guardar
            Usuario usuario = new Usuario();
            usuario.IdUsuario = 3;
            usuario.IdRol = 1;
            usuario.IdDepartamento = 1;
            usuario.IdMunicipio = 1;
            usuario.IdEstado = 1;
            usuario.Nombre = "Juan";
            usuario.Apellido = "Caceres";
            usuario.Telefono = "00220055";
            usuario.Contrasena = "123";
            usuario.CorreoElectronico = "erck@gmail.com";
            usuario.Dui = "123456789";
            usuario.Direccion = "Nahuizalco";
            usuario.UrlImagen = "urldelafoto";
            // Ejecutar metodo 
            int resultado = usuarioBL.Modificar(usuario);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se modifico correctamente
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void T3_ObtenerPorId()
        {
            // Buscar el empleado con id = 1
            Usuario usuario = usuarioBL.ObtenerPorId(1);

            // Comprobacion de la prueba
            // si el Id de Empleado es diferente de 0, la Empleado se obtuvo por Id correctamente
            Assert.AreNotEqual(0, usuario.IdUsuario);
        }

        [TestMethod]
        public void T4_Buscar()
        {
            List<Usuario> lista = usuarioBL.Buscar(new Usuario { Nombre = "Erick Wilfredo" });

            // Comprobacion de la prueba
            // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
            Assert.AreNotEqual(0, lista.Count);
        }
    }
}
