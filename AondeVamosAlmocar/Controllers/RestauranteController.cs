using ServiceContracts;
using StructureMap;
using System.Web.Mvc;
using Model;
using AondeVamosAlmocar.ViewModels;

namespace AondeVamosAlmocar.Controllers
{
    public class RestauranteController : Controller
    {
        private readonly IRestauranteServices RestauranteServices;

        public RestauranteController(IRestauranteServices restauranteServices)
        {
            RestauranteServices = restauranteServices;
        }

        public ActionResult Index()
        {
            var votarViewModel = new VotarViewModel
            {
                RestaurantesViewModel = new RestauranteViewModel
                {
                    Restaurantes = RestauranteServices.GetAllRestaurantes()
                }
            };

            return View(votarViewModel);
        }
    }
}
