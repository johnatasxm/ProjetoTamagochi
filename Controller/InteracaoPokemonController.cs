
using ProjetoTamagochi.Entities;
using ProjetoTamagochi.Menus;
using ProjetoTamagochi.Model;
using ProjetoTamagochi.Service;
using ProjetoTamagochi.Util;

namespace ProjetoTamagochi.Controller
{
    internal class InteracaoPokemonController : Menu
    {
        private Dictionary<int, Action> AcoesInteracao = new Dictionary<int, Action>();             
        private Mascote? Mascote { get; set; }
        internal InteracaoPokemonController(Mascote mascote)
        {
            this.Mascote = mascote;
        }
        internal void Iniciar()
        {
            AcoesInteracao.Clear();
            AcoesInteracao.Add(1, Mascote!.Brincar);
            AcoesInteracao.Add(2, Mascote.Alimentar);
            AcoesInteracao.Add(3, Mascote.Dormir);
            AcoesInteracao.Add(0, new MenuPrincipal().Executar);
            
            if (!Mascote!.StatusInicializado.HasValue) Mascote.InicializarStatus();            

            int opcao;

            while (true)
            {
                base.Executar();
                Logos.ExibirLogoPrincipal();
                Mascote.ExibirStatus();
                Console.WriteLine("\nO que deseja fazer?\n");
                Console.WriteLine("1 - Brincar");
                Console.WriteLine("2 - Alimentar");
                Console.WriteLine("3 - Dormir");
                Console.WriteLine("0 - Sair");

                while (true)
                {
                    try
                    {
                        Console.Write("\nDigite sua escolha: ");
                        opcao = int.Parse(Console.ReadLine()!);
                        if (opcao >= 0 && opcao <= 3) break;
                        throw new Exception();
                    }
                    catch
                    {
                        Console.WriteLine("Opção inválida. Digite novamente.");
                        Console.ReadKey();
                        Iniciar();
                    }
                }

                AcoesInteracao[opcao]();
                Mascote.VerificaPokemon();
            }
        }
       
    }
}