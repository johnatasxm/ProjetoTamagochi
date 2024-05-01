using ProjetoTamagochi.Entities;
using ProjetoTamagochi.Menus;

namespace ProjetoTamagochi.Controller
{
    internal class AdotarPokemonController : Menu
    {
        internal override void Executar()
        {
            base.Executar();
            Logos.ExibirLogoPrincipal();
            Console.WriteLine("\nMENU - ADOTAR POKÉMON\n");

            string nome;

            while (true)
            {
                try
                {
                    Console.Write("Digite o nome ou id do Pokémon que deseja adotar: ");
                    nome = Console.ReadLine()!;
                    if (!string.IsNullOrEmpty(nome)) break;
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Nome inválido. Favor digitar novamente.");
                    Console.ReadKey();
                    Executar();
                }
            }

            new Pokemon().AdotarPokemon(nome.ToLower());
            Console.ReadKey();
            new MenuPrincipal().Executar();
        }
    }
}