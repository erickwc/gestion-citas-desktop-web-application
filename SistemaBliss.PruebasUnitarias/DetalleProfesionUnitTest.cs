using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class DetalleProfesionUnitTest
    {
        // Conexion a la tabla de Empleados en la DB mediante una instancia de EmpleadoBL
        DetalleProfesionBL detalleProfesionBL = new DetalleProfesionBL();

        [TestMethod]
        public void T1_Guardar()
        {
            // instancia de Empleado con los datos a guardar
            DetalleProfesión detalleProfesion = new DetalleProfesión();
            detalleProfesion.IdProfesion = 1;
            detalleProfesion.IdUsuario = 1;
            // Ejecutar metodo 
            int resultado = detalleProfesionBL.Guardar(detalleProfesion);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se guardo correctamente
            Assert.AreEqual(1, resultado);
        }
        [TestMethod]
        public void T2_Modificar()
        {
            // instancia de Empleado con los datos a modificar
            DetalleProfesión detalleProfesión = new DetalleProfesión();
            detalleProfesión.IdDetalleProfesion = 10;
            detalleProfesión.IdUsuario = 1;
            detalleProfesión.IdProfesion = 2;
            // Ejecutar metodo
            int resultado = detalleProfesionBL.Modifiar(detalleProfesión);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se modifico correctamente
            Assert.AreEqual(1, resultado);
        }




        //[TestMethod]
        //public void T3_Buscar()
        //{
        //    List<DetalleProfesión> lista = detalleProfesionBL.Buscar(new DetalleProfesión { IdUsuario = 1 });

        //    // Comprobacion de la prueba
        //    // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
        //    Assert.AreNotEqual(0, lista.Count);
        //}
        //[TestMethod]
        //public void T4_ObtenerPorId()
        //{
        //    // Buscar el empleado con id = 1
        //    DetalleProfesión rol = detalleProfesionBL.ObtenerPorId(1);

        //    // Comprobacion de la prueba
        //    Assert.AreNotEqual(0, rol.IdDetalleProfesion);
        //}

    }
}