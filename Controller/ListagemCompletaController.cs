using ProjetoTamagochi.Entities;
using ProjetoTamagochi.Menus;

namespace ProjetoTamagochi.Controller
{
    internal class ListagemCompletaController : Menu
    {
        internal override void Executar()
        {
            base.Executar();
            Logos.ExibirLogoPrincipal();
            Console.WriteLine("\nMENU - LISTAR TODOS OS POKÉMONS\n");
            Console.Write("Digite quantos Pokémons deseja consultar (max. 1302): ");

            int qtdLimite;

            while (true)
            {
                try
                {
                    qtdLimite = int.Parse(Console.ReadLine()!);
                    if (qtdLimite > 0 && qtdLimite <= 1302) break;
                    throw new Exception();

                }
                catch
                {
                    Console.WriteLine("Número inválido. Favor digitar um número entre 1 e 1302.");
                    Console.ReadKey();
                    Executar();
                }
            }

            Pokemon.ListarPokemonsCompleto(qtdLimite);
            Console.ReadKey();
            new MenuPrincipal().Executar();
        }
    }
}