using System;
using System.Collections.Generic;
using DataContracts;
using Model;
using System.Linq;
namespace Data
{
    public class VotacaoRepository : IVotacaoRepository
    {
        private List<Voto> ResultadoVotacao;

        //TODO: criar a instacia do banco
        public VotacaoRepository()
        {
            ResultadoVotacao = new List<Voto>();
        }

        public bool Votar(int idUsuario, long idRestaurante)
        {
            //TODO: validar para não deixar votar no mesmo restaurante ou remover da lista de restaurantes

            //TODO: melhor opção é remover

            var jaExisteVoto = ResultadoVotacao.Exists(x => x.Data == DateTime.Today && x.IdRestaurante == idRestaurante && x.IdUsuario == idUsuario);
            if (jaExisteVoto)
                throw new Exception("Já existe um voto contabilizado para o dia de hoje.");

            ResultadoVotacao.Add(new Voto
            {
                Data = DateTime.Today,
                IdRestaurante = idRestaurante,
                IdUsuario = idUsuario
            });

            return true;
        }

        public IEnumerable<Voto> GetVotos(DateTime data)
        {
            return ResultadoVotacao.Where(voto => voto.Data == data);
        }

    }
}
