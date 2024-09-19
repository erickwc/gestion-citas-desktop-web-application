using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
// Referencias
using System.Collections.Generic;
// Referencias del proyecto
using SistemaBliss.EN;
using SistemaBliss.BL;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class ServicioUnitTest
    {
        // Conexion a la tabla de Servicio en la DB mediante una instancia de ServicioBL
        ServicioBL servicioBL = new ServicioBL();

        [TestMethod]
        public void T1_Guardar()
        {
            // instancia de Empleado con los datos a guardar
            Servicio servicio = new Servicio();
            servicio.IdCategoriaServicio = 1;
            servicio.IdEstado = 1;
            servicio.Nombre = "Corte de cabello en hongo";
            servicio.Descripción = "Perez";
            servicio.DiasAnticipacion = 12;
            servicio.Restricciones = "2";
            servicio.Precio = 0;
            servicio.Duracion = new TimeSpan(1, 0, 0); // 1 hora, 0 minutos, 0 segundos
            servicio.Imagen = "urldelafoto";

            // Ejecutar metodo 
            int resultado = servicioBL.Guardar(servicio);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se guardo correctamente
            Assert.AreEqual(1, resultado);
        }
        [TestMethod]
        public void T2_Modificar()
        {
            // instancia de Servicio con los datos a modificar
            Servicio servicio = new Servicio();
            servicio.IdServicio = 11;
            servicio.IdCategoriaServicio = 2;
            servicio.IdEstado = 1;
            servicio.Nombre = "Corte de bigote";
            servicio.Descripción = "Corte";
            servicio.DiasAnticipacion = 12;
            servicio.Restricciones = "2";
            servicio.Precio = 0;
            servicio.Duracion = new TimeSpan(1, 0, 0); // 1 hora, 0 minutos, 0 segundos
            servicio.Imagen = "urldelafoto";

            // Ejecutar metodo
            int resultado = servicioBL.Modificar(servicio);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Servicio se modifico correctamente
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void T3_ObtenerPorId()
        {
            // Buscar el empleado con id = 1
            Servicio servicio = servicioBL.ObtenerPorId(1);

            // Comprobacion de la prueba
            // si el Id de Empleado es diferente de 0, la Empleado se obtuvo por Id correctamente
            Assert.AreNotEqual(0, servicio.IdServicio);
        }

        //[TestMethod]
        //public void T4_Buscar()
        //{
        //    List<Servicio> lista = servicioBL.Buscar(new Servicio { Nombre = "Corte de Cabello para Hombres" });

        //    // Comprobacion de la prueba
        //    // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
        //    Assert.AreNotEqual(0, lista.Count);
        //}
    }

}