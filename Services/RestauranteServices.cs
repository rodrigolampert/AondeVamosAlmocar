using Model;
using ServiceContracts;
using System.Linq;
using System.Collections.Generic;

namespace Services
{
    public class RestauranteServices : IRestauranteServices
    {
        private static Dictionary<int, string> Restaurantes;

        public RestauranteServices()
        {
            if (Restaurantes == null)
                InicializaRestaurantesPreCadastrados();
        }

        /// <summary>
        /// Cria usuário para silular registros que já estaria no Banco de Dados
        /// </summary>
        private void InicializaRestaurantesPreCadastrados()
        {
            Restaurantes = new Dictionary<int, string>
            {
                { 1, "RU"},
                { 2, "R2 - Sabor Família"},
                { 3, "R3"},
                { 4, "Famecos"},
                { 5, "Odonto"},
                { 6, "Panorama"},
                { 7, "15"},
                { 8, "Espaço 32"},
                { 9, "Subway"},
                { 10, "Platus"},
                { 11, "Silva"},
                { 12, "Indiferente"}
            };
        }

        /// <summary>
        /// Retorna todos os restaurantes
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllRestaurantes() => Restaurantes;

        /// <summary>
        /// Recebe o ID do restaurante e reretorna o nome  
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetNomeRestaurante(int key)
        {
            return Restaurantes[key];
        }

    }
}
