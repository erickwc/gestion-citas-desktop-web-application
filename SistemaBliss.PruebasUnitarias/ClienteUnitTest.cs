using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;

namespace SistemaBliss.PruebasUnitarias
{
    [TestClass]
    public class ClienteUnitTest
    {
        // Conexion a la tabla de Cargos en la DB mediante una instancia de CargoBL
        ClienteBL clienteBL = new ClienteBL();

        [TestMethod]
        public void T1_Guardar()
        {
            // instancia de Empleado con los datos a guardar
            Cliente cliente = new Cliente();
            cliente.IdCliente = 9;
            cliente.IdUsuario = 9;
            cliente.ServiciosAcumulados = 9;

            // Ejecutar metodo 
            int resultado = clienteBL.Guardar(cliente);

            // Comprobacion de la prueba
            // si resultado es igual a 1, la Empleado se guardo correctamente
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void T1_ObtenerPorId()
        {
            // Buscar el cargo con id = 1
            Cliente cliente = clienteBL.ObtenerPorId(1);

            // Comprobacion de la prueba
            // si el Id de Cargo es diferente de 0, el Cliente se obtuvo por Id correctamente
            Assert.AreNotEqual(0, cliente.IdCliente);
        }


        [TestMethod]
        public void T4_Buscar()
        {
            List<Cliente> lista = clienteBL.Buscar(new Cliente { IdCliente = 11 });

            // Comprobacion de la prueba
            // si el total de la lista es diferente de 0, las Empleado se buscaron correctamente
            Assert.AreNotEqual(0, lista.Count);
        }



    }
}