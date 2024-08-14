using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class MunicipioUnitTest
    {
        MunicipioBL municipioBL = new MunicipioBL();

        [TestMethod]
        public void T4_ObtenerPorId()
        {
            // Buscar el empleado con id = 1
            Municipio municipio = municipioBL.ObtenerPorId(1);

            // Comprobacion de la prueba
            // si el Id de Empleado es diferente de 0, la Empleado se obtuvo por Id correctamente
            Assert.AreNotEqual(0, municipio.IdMunicipio);
        }

        [TestMethod]
        public void T5_Buscar()
        {
            List<Municipio> lista = municipioBL.Buscar(new Municipio { Nombre = "Nahuizalco" });

            // Comprobacion de la prueba
            // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
            Assert.AreNotEqual(0, lista.Count);
        }
    }
}
