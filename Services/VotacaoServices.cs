using Model;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class VotacaoServices : IVotacaoServices
    {
        private static RestauranteServices RestauranteServices;
        private static List<Voto> ResultadoVotacao;

        public VotacaoServices()
        {
            if (RestauranteServices == null)
                RestauranteServices = new RestauranteServices();

            if (ResultadoVotacao == null)
                InicializaVotacaoPreCadastrados();
        }

        /// <summary>
        /// Cria o Voto para a data de hoje
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idRestaurante"></param>
        /// <returns></returns>
        public bool Votar(int idUsuario, int idRestaurante)
        {
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse("12:00"))
                throw new Exception("Votação encerrada.");

            var jaExisteVoto = ResultadoVotacao.Exists(x => x.Data == DateTime.Today && x.IdRestaurante == idRestaurante && x.IdUsuario == idUsuario);
            if (jaExisteVoto)
                throw new Exception("Já existe um voto contabilizado para o dia de hoje.");

            ResultadoVotacao.Add(new Voto
            { 
                Data = DateTime.Today,
                IdRestaurante = idRestaurante,
                IdUsuario = idUsuario,
                NomeRestaurante = RestauranteServices.GetNomeRestaurante(idRestaurante)
            });

            return true;
        }

        /// <summary>
        /// Retorna todos os Votos que ocorreram na semana que a @data se encontra
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEnumerable<Voto> GetVotosDaSemana(DateTime data)
        {
            var datasDaSemana = BuscaDatasSemana();

            return ResultadoVotacao.Where(voto => datasDaSemana.Contains(voto.Data));
        }

        /// <summary>
        /// Busca todas as datas da semana cuja a data atual se encontra.
        /// Range => Segunda a Domingo
        /// </summary>
        /// <returns></returns>
        private List<DateTime> BuscaDatasSemana()
        {
            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }

            return Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();
        }
        /// <summary>
        /// Cria votos para silular registros que já estaria no Banco de Dados
        /// </summary>
        private void InicializaVotacaoPreCadastrados()
        {
            ResultadoVotacao = new List<Voto>
            {
                // Votacao para o dia de hoje
                new Voto
                {
                    Data = DateTime.Today,
                    IdRestaurante = 9,
                    IdUsuario = 1,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(9)
                },
                // Votacao para os dias anteriores a hoje
                new Voto
                {
                    Data = DateTime.Today.AddDays(-1),
                    IdRestaurante = 1,
                    IdUsuario = 1,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(1)
                },
                new Voto
                {
                    Data = DateTime.Today.AddDays(-1),
                    IdRestaurante = 1,
                    IdUsuario = 2,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(1)
                },
                new Voto
                {
                    Data = DateTime.Today.AddDays(-1),
                    IdRestaurante = 2,
                    IdUsuario = 3,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(2)
                },
                new Voto
                {
                    Data = DateTime.Today.AddDays(-2),
                    IdRestaurante = 1,
                    IdUsuario = 1,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(1)
                },
                new Voto
                {
                    Data = DateTime.Today.AddDays(-2),
                    IdRestaurante = 2,
                    IdUsuario = 2,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(2)
                },
                new Voto
                {
                    Data = DateTime.Today.AddDays(-2),
                    IdRestaurante = 3,
                    IdUsuario = 3,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(3)
                },
                new Voto
                {
                    Data = DateTime.Today.AddDays(-2),
                    IdRestaurante = 3,
                    IdUsuario = 4,
                    NomeRestaurante = RestauranteServices.GetNomeRestaurante(3)
                }
            };
        }
    }
}
