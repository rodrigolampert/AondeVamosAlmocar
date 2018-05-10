using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AondeVamosAlmocar.Controllers;
using ServiceContracts;
using AondeVamosAlmocar.App_Start;
using AondeVamosAlmocar.ViewModels;

namespace AondeVamosAlmocar.Tests.Controllers
{
    [TestClass]
    public class VotarControllerTest
    {
        public VotarControllerTest()
        {
            StructuremapMvc.Start();
        }

        /// <summary>
        /// Verifica se o método Index está carregando
        /// </summary>
        [TestMethod]
        public void Index()
        {
            VotarController controller = new VotarController(GetService<IUsuarioServices>(), GetService<IVotacaoServices>(), GetService<IRestauranteServices>());

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica se a lista de votos está sendo carregada do método Index
        /// </summary>
        [TestMethod]
        public void GetVotosIndex()
        {
            VotarController controller = new VotarController(GetService<IUsuarioServices>(), GetService<IVotacaoServices>(), GetService<IRestauranteServices>());

            ViewResult result = controller.Index() as ViewResult;

            var votarVm = (VotarViewModel)result.Model;

            Assert.IsTrue(votarVm.ResultadoVotacaoDataItem.Any());
        }

        /// <summary>
        /// Verifica se o método Create está carregando
        /// </summary>
        [TestMethod]
        public void Create()
        {
            VotarController controller = new VotarController(GetService<IUsuarioServices>(), GetService<IVotacaoServices>(), GetService<IRestauranteServices>());

            ViewResult result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica se a lista de usuarios está sendo carregada do método Create
        /// </summary>
        [TestMethod]
        public void GetUsuariosCreate()
        {
            VotarController controller = new VotarController(GetService<IUsuarioServices>(), GetService<IVotacaoServices>(), GetService<IRestauranteServices>());

            ViewResult result = controller.Create() as ViewResult;

            var votarVm = (VotarViewModel)result.Model;

            Assert.IsTrue(votarVm.UsuariosViewModel.Usuarios.Any());
        }


        /// <summary>
        /// Verifica se a criacao de voto está funcionando
        /// </summary>
        [TestMethod]
        public void VotarCreate()
        {
            VotarController controller = new VotarController(GetService<IUsuarioServices>(), GetService<IVotacaoServices>(), GetService<IRestauranteServices>());

            var votoVm = new VotarViewModel()
            {
                IdRestaurante = 1,
                IdUsuario = 1
            };

            ViewResult result = controller.Create(votoVm) as ViewResult;

            var error = (bool)result.ViewData["Error"];

            if (DateTime.Now.TimeOfDay > TimeSpan.Parse("12:00"))
            {
                Assert.IsFalse(error);
            }
            else
            {
                Assert.IsTrue(error);
            }
        }

        /// <summary>
        /// Verifica se as listas de restaurantes e usuários estão sendo carregadas
        /// </summary>
        [TestMethod]
        public void ListasRestUsu()
        {
            VotarController controller = new VotarController(GetService<IUsuarioServices>(), GetService<IVotacaoServices>(), GetService<IRestauranteServices>());

            var votoVm = new VotarViewModel();

            controller.CarregarListas(votoVm);

            var existeRestUsua = votoVm.RestaurantesViewModel.Restaurantes.Any() && votoVm.UsuariosViewModel.Usuarios.Any();

            Assert.IsTrue(existeRestUsua);
        }

        /// <summary>
        ///  Cria o servico Votar
        /// </summary>
        /// <returns></returns>
        public TService GetService<TService>()
        {
            return StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<TService>();
        }


    }
}
