using ProjetoTamagochi.Entities;
using ProjetoTamagochi.Menus;

namespace ProjetoTamagochi.Controller
{
    internal class EscolherPorNomeController : Menu
    {
        internal override void Executar()
        {
            base.Executar();
            Logos.ExibirLogoPrincipal();
            Console.WriteLine("\nMENU - CONSULTAR POKÉMON POR NOME\n");

            string nome;

            while (true)
            {
                try
                {
                    Console.Write("Digite o nome ou id do Pokémon que deseja consultar: ");
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

            Pokemon.ListarPokemonsPorNome(nome.ToLower());
            Console.ReadKey();
            new MenuPrincipal().Executar();
        }
    }
}