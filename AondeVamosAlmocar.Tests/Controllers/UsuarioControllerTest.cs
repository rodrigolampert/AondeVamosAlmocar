using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AondeVamosAlmocar.Controllers;
using ServiceContracts;
using AondeVamosAlmocar.App_Start;
using AondeVamosAlmocar.ViewModels;

namespace AondeVamosAlmocar.Tests.Controllers
{
    [TestClass]
    public class UsuarioControllerTest
    {
        /// <summary>
        /// Verifica se o método Index está carregando
        /// </summary>
        [TestMethod]
        public void Index()
        {
            UsuarioController controller = new UsuarioController(GetUsuarioService());

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica se a lista de usuarios está sendo carregada do método Index
        /// </summary>
        [TestMethod]
        public void GetUsuariosIndex()
        {
            UsuarioController controller = new UsuarioController(GetUsuarioService());

            ViewResult result = controller.Index() as ViewResult;

            var votarVm = (UsuarioViewModel)result.Model;

            Assert.IsTrue(votarVm.Usuarios.Any());
        }

        /// <summary>
        /// Verifica se o método Create está carregando
        /// </summary>
        [TestMethod]
        public void Create()
        {
            UsuarioController controller = new UsuarioController(GetUsuarioService());

            ViewResult result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica a criação de um usuário novo.
        /// Foi utilizado um GUID como nome para garantir que não exista
        /// </summary>
        [TestMethod]
        public void CreateUsuario()
        {
            var usuarioViewModel = new UsuarioViewModel
            {
                Nome = Guid.NewGuid().ToString()
            };

            UsuarioController controller = new UsuarioController(GetUsuarioService());

            ViewResult result = controller.Create(usuarioViewModel) as ViewResult;

            var error = (bool)result.ViewData["Error"];

            Assert.IsFalse(error);
        }

        /// <summary>
        /// Verifica a criação de um usuário já existente na base
        /// </summary>
        [TestMethod]
        public void CreateUsuarioExistente()
        {
            var usuarioViewModel = new UsuarioViewModel
            {
                Nome = "Rodrigo"
            };

            UsuarioController controller = new UsuarioController(GetUsuarioService());

            ViewResult result = controller.Create(usuarioViewModel) as ViewResult;

            var error = (bool)result.ViewData["Error"];

            Assert.IsTrue(error);
        }

        /// <summary>
        ///  Cria o servico usuário
        /// </summary>
        /// <returns></returns>
        public IUsuarioServices GetUsuarioService()
        {
            StructuremapMvc.Start();
            return StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IUsuarioServices>();
        }

    }
}
