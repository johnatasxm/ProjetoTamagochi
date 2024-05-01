using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTamagochi.Menus
{
    internal class MensagemAdeus: Menu
    {
        internal override void Executar()
        {
            Console.WriteLine("\nEsperamos que tenha se divertido. Até a próxima!");
            Environment.Exit(0);
        }
    }
}
