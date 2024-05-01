using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProjetoTamagochi.Util;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ProjetoTamagochi.Service;
using ProjetoTamagochi.Menus;

namespace ProjetoTamagochi.Entities
{
    internal class Pokemon
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("base_experience")]
        public int? NivelExperiencia { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<JsonObject>? Abilities { get; set; }

        [JsonPropertyName("types")]
        public List<JsonObject>? Types { get; set; }

        [JsonPropertyName("stats")]
        public List<JsonObject>? Stats { get; set; }

        [JsonIgnore]
        internal static List<Pokemon>? PokemonsAdotados { get; set; } = [];


        internal static void ListarPokemonsCompleto(int qtdLimite)
        {
            try
            {
                var solicitacao = ApiRequestService.EnviarRequisicao($"?offset=0&limit={qtdLimite}");                

                Console.WriteLine($"\nLista completa de Pokémons (Tamanho da lista: {qtdLimite}) \n");
                ListarSomenteNomes(solicitacao);

            }
            catch
            {
                Console.WriteLine("\nQue pena! A API do Pokémon parece estar fora do ar.");                
            }
        }
        

        internal static void ListarPokemonsSelecionados()
        {
            Console.WriteLine($"\nLista de Pokémons adotados: \n");            

            foreach (var pokemon in PokemonsAdotados!)
            {
                ExibirInfoCompletas(pokemon);
            }
        }

        internal static void ListarPokemonsPorNome(String nome)
        {           
            try
            {
                var solicitacao = ApiRequestService.EnviarRequisicao(nome);

                var pokemon = DeserializarPokemon(solicitacao);
                Console.WriteLine($"\nListando informações do Pokémon - " +
                    $"{ConversorTextoService.ToPascalCase(pokemon.Name!)}: \n");
                ExibirInfoCompletas(pokemon);
            }
            catch 
            {
                Console.WriteLine("Pokémon não encontrado. Favor digitar novamente."); ;
            }  

        }


        private static void ExibirInfoCompletas(Pokemon pokemon)
        {     
            Console.WriteLine($"#{pokemon.Id}: " +
                            $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pokemon.Name!)}");

            Console.WriteLine($"\tNível de Experiência: {pokemon.NivelExperiencia}");
            Console.WriteLine($"\tAltura: {pokemon.Height}");
            Console.WriteLine($"\tPeso: {pokemon.Weight}");

            Console.WriteLine("\tHabilidades: ");
            foreach (var ability in pokemon.Abilities!)
            {
                Console.WriteLine($"\t\t-{ConversorTextoService.ToPascalCase
                    (ability["ability"]!["name"]!.ToString()!)}");
            }

            Console.WriteLine("\tTipos: ");
            foreach (var type in pokemon.Types!)
            {
                Console.WriteLine($"\t\t-{ConversorTextoService.ToPascalCase
                    (type["type"]!["name"]!.ToString()!)}");
            }

            Console.WriteLine("\tDados: ");
            foreach (var stat in pokemon.Stats!)
            {
                Console.WriteLine($"\t\t-{ConversorTextoService.ToPascalCase
                    (stat!["stat"]!["name"]!.ToString())}: {stat!["base_stat"]}");
            }

            Console.WriteLine();
        }


        private static void ListarSomenteNomes(string solicitacao)
        {
            var nomes = JsonNode.Parse(solicitacao)!["results"];

            foreach (var nome in nomes!.AsArray())
            {
                Console.WriteLine($"#{nome!["url"]!.ToString().Split("/")[6]}: " +
                    $"{ConversorTextoService.ToPascalCase(nome!["name"]!.ToString())}");
            }
        }

        private static Pokemon DeserializarPokemon (string response)
        {
            return JsonSerializer.Deserialize<Pokemon>(response)!;
        }

        internal void AdotarPokemon(string nome)
        {
            try
            {
                var solicitacao = ApiRequestService.EnviarRequisicao(nome);
                
                var pokemon = DeserializarPokemon(solicitacao);
                PokemonsAdotados!.Add(pokemon);
                Console.WriteLine($"\nParabéns! Você adotou o Pokémon - " +
                    $"{ConversorTextoService.ToPascalCase(pokemon.Name!)}!");
            }
            catch 
            {
                Console.WriteLine("Pokémon não encontrado. Favor digitar novamente."); ;
            }
        }
        
    }
}
