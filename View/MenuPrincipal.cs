using ProjetoTamagochi.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTamagochi.Menus
{
    internal class MenuPrincipal: Menu
    {
        private Dictionary<int, Menu> menu = new Dictionary<int, Menu>()
        {
            {1, new ListagemCompletaController() },
            {2, new EscolherPorNomeController() },
            {3, new AdotarPokemonController() },
            {4, new ListarAdotadosController() },
            {5, new BrincarPokemonController() },
            {0, new MensagemAdeus() }
        };

        internal override void Executar()
        {
            base.Executar();

            Logos.ExibirLogoPrincipal();
            Console.WriteLine("\nMENU PRINCIPAL\n");
            Console.WriteLine("1 - Listar todos os Pokémons");
            Console.WriteLine("2 - Consultar detalhes de Pokémon por nome ou id");
            Console.WriteLine("3 - Adotar Pokémon");
            Console.WriteLine("4 - Listar detalhes de Pokémons adotados");
            Console.WriteLine("5 - Brincar com Pokémons adotados");
            Console.WriteLine("0 - Sair");            

            int opcao;

            while (true)
            {
                try
                {
                    Console.Write("\nDigite a opção desejada: ");
                    opcao = int.Parse(Console.ReadLine()!);
                    if (opcao >= 0 && opcao <= 5) break;
                    throw new Exception();
                }
                catch 
                {
                    Console.WriteLine("Opção inválida. Escolha novamente.");
                    Console.ReadKey();
                    this.Executar();
                }
            }            

            menu[opcao].Executar();

        }
    }
}
