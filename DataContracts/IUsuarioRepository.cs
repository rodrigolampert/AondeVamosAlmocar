using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public interface IUsuarioRepository
    {
        bool Create(Usuario usuario);
    }
}
