using ProjetoTamagochi.Entities;
using ProjetoTamagochi.Menus;

namespace ProjetoTamagochi.Controller
{
    internal class ListarAdotadosController : Menu
    {
        internal override void Executar()
        {
            base.Executar();
            Logos.ExibirLogoPrincipal();
            Console.WriteLine("\nMENU - LISTAR DETALHES DE POKÉMONS ADOTADOS");

            if (!Pokemon.PokemonsAdotados!.Any())
            {
                Console.WriteLine("\nParece que você ainda não adotou nenhum Pokémon. " +
                    "Adote um e volte para ver os detalhes!");
                Console.ReadKey();
                new MenuPrincipal().Executar();
            }

            Pokemon.ListarPokemonsSelecionados();
            Console.ReadKey();
            new MenuPrincipal().Executar();
        }
    }
}