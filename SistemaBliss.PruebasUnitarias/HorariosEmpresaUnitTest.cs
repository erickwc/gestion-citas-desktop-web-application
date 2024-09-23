using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class HorariosEmpresaUnitTest
    {

        HorariosEmpresaBL horariosBl = new HorariosEmpresaBL();

        [TestMethod]
        public void T1_Guardar()
        {
            // instancia de Empleado con los datos a guardar
            HorariosEmpresa horariosEmpresa = new HorariosEmpresa();
            horariosEmpresa.IdEmpresa = 1;
            horariosEmpresa.Dias = "Lunes";
            horariosEmpresa.HoraEntrada = new TimeSpan(8, 30, 00);
            horariosEmpresa.HoraSalida = new TimeSpan(12, 30, 00);

            // Ejecutar metodo 
            int resultado = horariosBl.Guardar(horariosEmpresa);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se guardo correctamente
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void T1_Modificar()
        {
            // instancia de Empleado con los datos a guardar
            HorariosEmpresa horariosEmpresa = new HorariosEmpresa();
            horariosEmpresa.IdHorariosEmpresa = 1;
            horariosEmpresa.IdEmpresa = 1;
            horariosEmpresa.Dias = "Lunes";
            horariosEmpresa.HoraEntrada = new TimeSpan(8, 30, 00);
            horariosEmpresa.HoraSalida = new TimeSpan(12, 30, 00);

            // Ejecutar metodo 
            int resultado = horariosBl.Modificar(horariosEmpresa);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se guardo correctamente
            Assert.AreEqual(1, resultado);
        }


        //[TestMethod]
        //public void T4_Buscar()
        //{
        //    List<HorariosEmpresa> lista = horariosBl.Buscar(new HorariosEmpresa { });

        //    // Comprobacion de la prueba
        //    // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
        //    Assert.AreNotEqual(0, lista.Count);
        //}
    }

}
