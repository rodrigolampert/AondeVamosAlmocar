using ServiceContracts;
using System.Linq;
using System.Web.Mvc;
using Model;
using AondeVamosAlmocar.ViewModels;
using System;

namespace AondeVamosAlmocar.Controllers
{
    public class VotarController : Controller
    {
        private readonly IUsuarioServices UsuarioServices;
        private readonly IVotacaoServices VotacaoServices;
        private readonly IRestauranteServices RestauranteServices;

        public VotarController(IUsuarioServices usuarioServices, IVotacaoServices votacaoServices, IRestauranteServices restauranteServices)
        {
            UsuarioServices = usuarioServices;
            VotacaoServices = votacaoServices;
            RestauranteServices = restauranteServices;
        }

        public ActionResult Index()
        {
            var votarViewModel = new VotarViewModel();

            var resultadoVotacao = VotacaoServices.GetVotosDaSemana(DateTime.Today);

            votarViewModel.ResultadoVotacaoDataItem =
                (from votos in resultadoVotacao
                 group votos by new { votos.IdRestaurante, votos.Data }
                     into grouped
                 select new VotacaoDataItem
                 {
                     IdRestaurante = grouped.Key.IdRestaurante,
                     NmRestaurante = grouped.ToList().First().NomeRestaurante,
                     Data = grouped.Key.Data,
                     QtdVotos = grouped.ToList().Count
                 })
                     .ToList();

            return View(votarViewModel);
        }

        public ActionResult Create()
        {
            var votarViewModel = new VotarViewModel();

            votarViewModel.RestaurantesViewModel = new RestauranteViewModel
            {
                Restaurantes = RestauranteServices.GetAllRestaurantes()
            };

            votarViewModel.UsuariosViewModel = new UsuarioViewModel
            {
                Usuarios = UsuarioServices.GetAllUsuarios()
            };

            return View(votarViewModel);
        }

        [HttpPost]
        public ActionResult Create(VotarViewModel votarViewModel)
        {
            CarregarListas(votarViewModel);
            
            if (ModelState.IsValid)
            {
                try
                {
                    var result = VotacaoServices.Votar(votarViewModel.IdUsuario.Value, votarViewModel.IdRestaurante.Value);

                    ViewBag.Result = result ? "Voto registrado com sucesso." : "Falha ao registrar o voto.";
                    ViewBag.Error = false;
                }
                catch (Exception e)
                {
                    ViewBag.Result = $"Falha ao Votar. { e.Message}";
                    ViewBag.Error = true;
                }
            }

            return View(votarViewModel);
        }

        public void CarregarListas(VotarViewModel votarViewModel)
        {
            var votosDaSemana = VotacaoServices.GetVotosDaSemana(DateTime.Today);

            var restVencedores =
                (from votos in votosDaSemana
                 group votos by new { votos.IdRestaurante, votos.Data }
                     into grouped
                 select new VotacaoDataItem
                 {
                     IdRestaurante = grouped.Key.IdRestaurante,
                     NmRestaurante = grouped.ToList().First().NomeRestaurante,
                     Data = grouped.Key.Data,
                     QtdVotos = grouped.ToList().Count
                 })
                 .GroupBy(votacao => votacao.Data)
                 .Select(votacaoGrouped => votacaoGrouped.First(x => x.QtdVotos == votacaoGrouped.Max(y => y.QtdVotos)))
                 .ToList();

            var restaurantes = RestauranteServices.GetAllRestaurantes();

            foreach (var venc in restVencedores)
                restaurantes.Remove(venc.IdRestaurante);


            votarViewModel.RestaurantesViewModel = new RestauranteViewModel
            {
                Restaurantes = restaurantes
            };

            votarViewModel.UsuariosViewModel = new UsuarioViewModel
            {
                Usuarios = UsuarioServices.GetAllUsuarios()
            };
        }
    }
}
