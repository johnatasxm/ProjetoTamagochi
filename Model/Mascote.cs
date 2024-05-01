using ProjetoTamagochi.Entities;
using ProjetoTamagochi.Menus;
using ProjetoTamagochi.Service;
using ProjetoTamagochi.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoTamagochi.Model
{
    internal class Mascote
    {
        public string? Name { get; set; }

        public int? Id { get; set; }

        private int? Comida { get; set; }

        private int? Felicidade { get; set; }

        private int? Energia { get; set; }

        internal bool? StatusInicializado { get; set; }

        internal void InicializarStatus()
        {
            Comida = NumeroAleatorioService.GerarNumeroAleatorio(1, 10);
            Felicidade = NumeroAleatorioService.GerarNumeroAleatorio(1, 10);
            Energia = NumeroAleatorioService.GerarNumeroAleatorio(1, 10);
            StatusInicializado = true;
        }

        internal void ExibirStatus()
        {
            var nome = ConversorTextoService.ToPascalCase(Name!);

            Console.WriteLine($"\nStatus do Pokémon - {nome}: \n");
            Console.WriteLine($"\tAlimentação: {nome} está " +
                $"{(Comida <= 3 ? "com fome" : "satisfeito")}!"); // - Valor: {Comida}");
            Console.WriteLine($"\tAlegria: {nome} está " +
                $"{(Felicidade <= 4 ? "triste" : "feliz")}!"); // - Valor: {Felicidade}");
            Console.WriteLine($"\tEnergia: {nome} está " +
                $"{(Energia <= 3 ? "com sono" : "desperto")}!"); // - Valor:  {Energia}");
        }

        internal void Brincar()
        {
            Felicidade += NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
            Energia -= NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
            Comida -= NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
        }

        internal void Alimentar()
        {
            Felicidade -= NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
            Energia -= NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
            Comida += NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
        }

        internal void Dormir()
        {
            Felicidade -= NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
            Energia += NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
            Comida -= NumeroAleatorioService.GerarNumeroAleatorio(1, 4);
        }

        internal void VerificaPokemon()
        {
            if (Comida <= 0)
            {
                Console.WriteLine("\nQue pena, seu bichinho morreu!");
                Pokemon.PokemonsAdotados!.RemoveAll(x => x.Name!.Equals(Name));
                Console.WriteLine($"\nInfelizmente, {ConversorTextoService.ToPascalCase(Name!)} não está mais entre nós.");
                Console.ReadKey();
                new MenuPrincipal().Executar();
            }

            if (Comida > 10) Comida = 10;
            if (Felicidade > 10) Felicidade = 10;
            if (Energia > 10) Energia = 10;
            if (Felicidade < 0) Felicidade = 0;
            if (Energia < 0) Energia = 0;
        }

    }
}
