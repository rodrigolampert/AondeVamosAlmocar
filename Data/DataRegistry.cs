using DataContracts;
using StructureMap;

namespace Data
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IUsuarioRepository>().Use<UsuarioRepository>();
            For<IVotacaoRepository>().Use<VotacaoRepository>();
        }
    }
}
