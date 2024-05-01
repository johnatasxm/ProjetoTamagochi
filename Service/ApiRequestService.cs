using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTamagochi.Util
{
    internal class ApiRequestService
    {
        internal static string EnviarRequisicao(string parametro)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri($"https://pokeapi.co/api/v2/pokemon/{parametro}");
                    var response = client.GetStringAsync(client.BaseAddress).Result;

                    return response;
                }
                catch 
                {
                    throw;
                }

            }
        }
    }
}
