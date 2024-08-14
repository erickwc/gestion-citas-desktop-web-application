using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class RolUnitTest
    {
        RolBL rolBL = new RolBL();

        [TestMethod]
        public void T4_ObtenerPorId()
        {
            // Buscar el empleado con id = 1
            Rol rol = rolBL.ObtenerPorId(1);

            // Comprobacion de la prueba
            Assert.AreNotEqual(0, rol.IdRol);
        }

        [TestMethod]
        public void T5_Buscar()
        {
            List<Rol> lista = rolBL.Buscar(new Rol { Nombre = "Gerente" });

            // Comprobacion de la prueba
            // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
            Assert.AreNotEqual(0, lista.Count);
        }
    }
}


