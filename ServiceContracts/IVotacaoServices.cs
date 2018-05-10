using Model;
using System;
using System.Collections.Generic;

namespace ServiceContracts
{
    public interface IVotacaoServices
    {
        bool Votar(int idUsuario, int idRestaurante);

        IEnumerable<Voto> GetVotosDaSemana(DateTime data);
    }
}
