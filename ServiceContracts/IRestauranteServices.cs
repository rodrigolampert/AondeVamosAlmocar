using Model;
using System;
using System.Collections.Generic;

namespace ServiceContracts
{
    public interface IRestauranteServices
    {
        Dictionary<int, string> GetAllRestaurantes();
    }
}
