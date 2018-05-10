using ServiceContracts;
using StructureMap;
using System.Web.Mvc;
using Model;
using AondeVamosAlmocar.ViewModels;

namespace AondeVamosAlmocar.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices UsuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            UsuarioServices = usuarioServices;
        }

        public ActionResult Index()
        {
            var usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Usuarios = UsuarioServices.GetAllUsuarios();
            return View(usuarioViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            var result = UsuarioServices.Create(usuarioViewModel.Nome);

            ViewBag.Result = result ? "Usuário criado com sucesso." : "Usuário já existe.";
            ViewBag.Error = !result;

            return View(usuarioViewModel);
        }
    }
}
