using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class DepartamentoUnitTest
    {
        DepartamentoBL departamentoBL = new DepartamentoBL();

        [TestMethod]
        public void T4_ObtenerPorId()
        {
            // Buscar el empleado con id = 1
            Departamento departamento = departamentoBL.ObtenerPorId(1);

            // Comprobacion de la prueba
            // si el Id de Empleado es diferente de 0, la Empleado se obtuvo por Id correctamente
            Assert.AreNotEqual(0, departamento.IdDepartamento);
        }

        [TestMethod]
        public void T5_Buscar()
        {
            List<Departamento> lista = departamentoBL.Buscar(new Departamento { Nombre = "Sonsonate" });

            // Comprobacion de la prueba
            // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
            Assert.AreNotEqual(0, lista.Count);
        }

    }
}
