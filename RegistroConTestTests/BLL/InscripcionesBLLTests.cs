using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroConTest.BLL;
using RegistroConTest.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroConTest.BLL.Tests
{
    [TestClass()]
    public class InscripcionesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionID = 0;
            inscripcion.PersonaID = 0;
            inscripcion.Monto = 5000.99f;
            inscripcion.Balance = 3500.50f;
            inscripcion.Comentarios = "Trabajo de wilbert";

            paso = InscripcionesBLL.Guardar(inscripcion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionID = 0;
            inscripcion.PersonaID = 0;
            inscripcion.Monto = 5000.99f;
            inscripcion.Balance = 3500.50f;
            inscripcion.Comentarios = "Trabajo de wilbert";

            paso = InscripcionesBLL.Modificar(inscripcion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = InscripcionesBLL.Eliminar(2);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscripcion = new Inscripciones();
            inscripcion= InscripcionesBLL.Buscar(2);
            Assert.AreNotEqual(inscripcion, null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}