using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortalDenuncia.Models;

namespace UnitDenunciaTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProbandoUsuariosRegistrados()
        {
            //
            var persona = new TBUSUARIO();
            var numero = "12354789";
            //
            var resultado = persona.ValidarUsuario(numero);
            //
            Assert.IsTrue(resultado);
        }
    }
}
