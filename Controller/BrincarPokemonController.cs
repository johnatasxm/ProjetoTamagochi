using AutoMapper;
using ProjetoTamagochi.Entities;
using ProjetoTamagochi.Menus;
using ProjetoTamagochi.Model;
using ProjetoTamagochi.Service;
using ProjetoTamagochi.Util;

namespace ProjetoTamagochi.Controller
{
    internal class BrincarPokemonController : Menu
    {
        internal override void Executar()
        {
            base.Executar();
            Logos.ExibirLogoPrincipal();
            Console.WriteLine("\nMENU - BRINCAR COM POKÉMONS ADOTADOS\n");

            if (!Pokemon.PokemonsAdotados!.Any())
            {
                Console.WriteLine("Parece que você ainda não adotou nenhum Pokémon. " +
                    "Adote um e volte para brincar!");
                Console.ReadKey();
                new MenuPrincipal().Executar();
            }

            Console.WriteLine("Lista de Pokemons adotados: \n");
                        
            foreach (var pokemon in Pokemon.PokemonsAdotados!)
            {
                Console.WriteLine($"#{pokemon.Id}: {ConversorTextoService.ToPascalCase(pokemon.Name!)}");
            }

            string escolha = string.Empty;
            int resultado;

            while (true)
            {
                try
                {
                    
                    Console.Write("\nDigite o nome ou id do Pokemon com o qual deseja brincar: ");
                    escolha = Console.ReadLine()!;
                    int.TryParse(escolha, out resultado);
                    if (Pokemon.PokemonsAdotados
                        .Any(x => x.Name!.Equals(escolha.ToLower()) || x.Id.Equals(resultado))) break;
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Opção inválida. Favor digitar novamente.");
                    Console.ReadKey();
                    Executar();

                }
            }

            var pokemonSelecionado = Pokemon.PokemonsAdotados
                    .Where(x => x.Name!.Equals(escolha.ToLower()) || x.Id == resultado).First();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pokemon, Mascote>()).CreateMapper();
            Mascote mascote = mapper.Map<Mascote>(pokemonSelecionado);

            new InteracaoPokemonController(mascote).Iniciar();        

            Console.ReadKey();
            new MenuPrincipal().Executar();
        }
    }
}