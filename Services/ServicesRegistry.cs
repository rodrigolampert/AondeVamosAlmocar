using ServiceContracts;
using StructureMap;

namespace Services
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            For<IVotacaoServices>().Use<VotacaoServices>();
            For<IUsuarioServices>().Use<UsuarioServices>();
            For<IRestauranteServices>().Use<RestauranteServices>();
        }
    }
}
