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
            //Organizar
            var persona = new TBUSUARIO();
            var mockusuarios = new Mock<TBUSUARIO>();
            mockusuarios.SetupGet(x => x.usuariop).Returns();
            var numero = "12354789";
            //Actuar
            var resultado = persona.ValidarUsuario(numero);
            //Afirmar
            Assert.IsTrue(resultado);
        }*/

        /*
        [TestMethod]
        public void ProbandoelmensajeErrorViewbag()
        {
            
            //Organizar
            string documentos = null;
            TBUSUARIO usuarioprueba = new TBUSUARIO();

            usuarioprueba.ValidarUsuario = false;

            var mockTbusuario = new Mock<TBUSUARIO>();
            mockTbusuario.Setup(sp => sp.ValidarUsuario(documentos)).Returns(false);

            //Actuar
            UsuariosController control = new UsuariosController(mockTbusuario.Object);

            var resultado = control.Create(usuarioprueba);

            //Afirmar
            Assert.IsNotNull(resultado)
        }
        */

        [TestMethod]
        public void ProbandoDevulucionViewUsuariosController()
        {
            //Organizar
            UsuariosController control = new UsuariosController();
            //Actuar
            ViewResult resultado = control.Create() as ViewResult;
            //Afirmar
            Assert.IsNotNull(resultado);
        }

    }
}
