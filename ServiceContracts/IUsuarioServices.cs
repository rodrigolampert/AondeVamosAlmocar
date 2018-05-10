using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IUsuarioServices
    {
        bool Create(string nomeUsuario);

        List<Usuario> GetAllUsuarios();
    }
}
