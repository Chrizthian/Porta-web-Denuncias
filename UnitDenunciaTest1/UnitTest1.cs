using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PortalDenuncia.Controllers;
using PortalDenuncia.Models;

namespace UnitDenunciaTest1
{
    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void ProbandoUsuariosRegistrados()
        {
            //
            var persona = new TBUSUARIO();
            var mockusuarios = new Mock<TBUSUARIO>();
            mockusuarios.SetupGet(x => x.usuariop).Returns();
            var numero = "12354789";
            //
            var resultado = persona.ValidarUsuario(numero);
            //
            Assert.IsTrue(resultado);
        }*/

        /*
        [TestMethod]
        public void ProbandoelmensajeErrorViewbag()
        {
            

            string documentos = null;
            TBUSUARIO usuarioprueba = new TBUSUARIO();

            usuarioprueba.ValidarUsuario = false;

            var mockTbusuario = new Mock<TBUSUARIO>();
            mockTbusuario.Setup(sp => sp.ValidarUsuario(documentos)).Returns(false);

            UsuariosController control = new UsuariosController(mockTbusuario.Object);

            var resultado = control.Create(usuarioprueba);


            Assert.IsNotNull(resultado)
        }
        */

        [TestMethod]
        public void ProbandoDevulucionViewUsuariosController()
        {
            UsuariosController control = new UsuariosController();

            ViewResult resultado = control.Create() as ViewResult;

            Assert.IsNotNull(resultado);
        }

    }
}
