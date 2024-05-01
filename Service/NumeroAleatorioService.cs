using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTamagochi.Service
{
    internal class NumeroAleatorioService
    {
        internal static int GerarNumeroAleatorio(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }
    }
}
