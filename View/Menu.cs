using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTamagochi.Menus
{
    abstract internal class Menu
    {
        internal virtual void Executar()
        {
            Console.Clear();
        }
    }
}
