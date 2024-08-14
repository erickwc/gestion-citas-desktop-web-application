using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class EmpresaUnitTest
    {
        EmpresaBL empresaBL = new EmpresaBL();

        [TestMethod]
        public void T1_Modificar()
        {
            // instancia de Empleado con los datos a guardar
            Empresa empresa = new Empresa();
            empresa.IdEmpresa = 1;
            empresa.Nombre = "BLISS";
            empresa.Telefono = "77774522";
            empresa.Direccion = "Izalco";
            empresa.CorreoElectronico = "bliss@gmail.com";
            // Ejecutar metodo 
            int resultado = empresaBL.Modificar(empresa);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se guardo correctamente
            Assert.AreEqual(1, resultado);
        }



        [TestMethod]
        public void T3_ObtenerPorId()
        {
            // Buscar el empleado con id = 1
            Empresa empresa = empresaBL.ObtenerPorId(1);

            // Comprobacion de la prueba
            // si el Id de Empleado es diferente de 0, la Empleado se obtuvo por Id correctamente
            Assert.AreNotEqual(0, empresa.IdEmpresa);
        }

        [TestMethod]
        public void T4_Buscar()
        {
            List<Empresa> lista = empresaBL.Buscar(new Empresa { Nombre = "BLISS" });

            // Comprobacion de la prueba
            // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
            Assert.AreNotEqual(0, lista.Count);
        }
    }

}
