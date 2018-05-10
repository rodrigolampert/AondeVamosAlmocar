using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AondeVamosAlmocar.ViewModels
{
    public class VotarViewModel
    {
        public VotarViewModel()
        {
            RestaurantesViewModel = new RestauranteViewModel();
        }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int? IdRestaurante { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int? IdUsuario { get; set; }

        public RestauranteViewModel RestaurantesViewModel { get; set; }
        public UsuarioViewModel UsuariosViewModel { get; set; }
        public List<VotacaoDataItem> ResultadoVotacaoDataItem { get; set; }


    }
}