using Model;
using System;
using System.Collections.Generic;

namespace DataContracts
{
    public interface IVotacaoRepository
    {
        bool Votar(int idUsuario, long idRestaurante);

        IEnumerable<Voto> GetVotos(DateTime data);
    }
}
