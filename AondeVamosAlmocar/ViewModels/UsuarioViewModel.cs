using Model;
using System.Collections.Generic;

namespace AondeVamosAlmocar.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}