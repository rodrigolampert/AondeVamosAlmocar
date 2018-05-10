using Model;
using ServiceContracts;
using System.Linq;
using System.Collections.Generic;

namespace Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private static List<Usuario> Usuarios;

        public UsuarioServices()
        {
            if (Usuarios == null)
                InicializaUsuariosPreCadastrados();
        }

        /// <summary>
        /// Cria usuários para silular registros que já estaria no Banco de Dados
        /// </summary>
        private void InicializaUsuariosPreCadastrados()
        {
            Usuarios = new List<Usuario>
            {
                new Usuario{ Nome = "Rodrigo", Id = 1 },
                new Usuario{ Nome = "Gustavo", Id = 2 },
                new Usuario{ Nome = "Pedro", Id = 3 },
                new Usuario{ Nome = "Paulo", Id = 4 }
            };
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="nomeUsuario"></param>
        /// <returns></returns>
        public bool Create(string nomeUsuario)
        {
            if (Usuarios.Exists(u => u.Nome.ToUpper().Equals(nomeUsuario.ToUpper())))
                return false;

            var nextId = Usuarios.Max(u => u.Id) + 1;
            Usuarios.Add(new Usuario
            {
                Nome = nomeUsuario,
                Id = nextId
            });

            return true;
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetAllUsuarios() => Usuarios;

    }
}
