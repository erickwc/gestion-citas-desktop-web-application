using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//Referencias del proyeccto
using SistemaBliss.EN;
using SistemaBliss.BL;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class ProfesionUnitTest1
    {
        // Conexion a la tabla de Profesion en la DB mediante una instancia de CargoBL
        //ProfesionBL profesionBL = new ProfesionBL();

        //[TestMethod]
        //public void T1_ObtenerPorId()
        //{
        //    // Buscar el cargo con id = 1
        //    Profesión profesión = profesionBL.ObtenerPorId(1);

        //    // Comprobacion de la prueba
        //    // si el Id de Cargo es diferente de 0, el Cargo se obtuvo por Id correctamente
        //    Assert.AreNotEqual(0, profesión.IdProfesión);
        //}
        //[TestMethod]
        //public void T2_Buscar()
        //{
        //    List<Profesión> lista = profesionBL.Buscar(new Profesión { Nombre = "Barbero" });

        //    // Comprobacion de la prueba
        //    // si el total de la lista es diferente de 0, los Cargos se buscaron correctamente
        //    Assert.AreNotEqual(0, lista.Count);
        //}
        //public void T3_Guardar()
        //{
        //    // instancia de Empleado con los datos a guardar
        //    Profesión profesion = new Profesión();
        //    profesion.IdProfesión = 1;
        //    profesion.Nombre = "Erick";
        //    // Ejecutar metodo 
        //    int resultado = profesionBL.Guardar(profesion);

        //    // Comprobacion de la prueba
        //    // si resultado es igual a 1, la Empleado se guardo correctamente
        //    Assert.AreEqual(1, resultado);
        //}
        //public void T4_Modificar()
        //{
        //    // instancia de Empleado con los datos a modificar
        //    Profesión profesión = profesionBL.ObtenerPorId(1);
        //    profesión.IdProfesión = 1;
        //    profesión.Nombre = "Mario";
        //    // Ejecutar metodo
        //    int resultado = profesionBL.Modificar(profesión);

        //    // Comprobacion de la prueba
        //    // si resultado es igual a 1, la Empleado se modifico correctamente
        //    Assert.AreEqual(1, resultado);
        //}

    }

}