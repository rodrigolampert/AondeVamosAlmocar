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
    public class RestauranteControllerTest
    {
        /// <summary>
        /// Verifica se método Index está carregando
        /// </summary>
        [TestMethod]
        public void Index()
        {
            RestauranteController controller = new RestauranteController(GetRestauranteService());

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica se a lista de restaurantes está sendo carregada
        /// </summary>
        [TestMethod]
        public void GetRestaurantes()
        {
            RestauranteController controller = new RestauranteController(GetRestauranteService());

            ViewResult result = controller.Index() as ViewResult;

             var votarVm = (VotarViewModel)result.Model;

            Assert.IsTrue(votarVm.RestaurantesViewModel.Restaurantes.Any());
        }

        /// <summary>
        ///  Cria o servico restaurante
        /// </summary>
        /// <returns></returns>
        public IRestauranteServices GetRestauranteService()
        {
            StructuremapMvc.Start();
            return StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IRestauranteServices>();
        }

    }
}
