using System;
using System.Collections.Generic;
using SpaceshipLab.Core;
using SpaceshipLab.Core.Observador;
using SpaceshipLab.Crew;
using SpaceshipLab.Arsenal;
using SpaceshipLab.Arsenal.Armas;
using SpaceshipLab.Arsenal.Modificadores;

namespace SpaceshipLab
{  
    /// <summary>
    /// Ponto de entrada do programa. Não é peça de nenhum padrão específico
    /// é quem monta o cenário inicial, ele cria o núcleo, inscreve os observadores,
    /// cria a nave e o dicionário de tripulantes e conduz o menu principal,
    /// direcionando pra cada submenu (Núcleo, Tripulação, Armamento) conforme
    /// a opção escolhida pelo jogador.
    /// </summary>
    class Programa
    {   

        /// Recebe os argumentos de linha de comando (não usados aqui).
        /// é o método que o .NET chama automaticamente
        /// ao iniciar a execução do programa.
        static void Main(string[] args)
        {  
            // Cria o núcleo e inscreve os três observadores concretos.
            // A partir daqui o núcleo só conhece IObservadorNucleo, nunca
            // essas classes por nome.
            var nucleo = new NucleoNave();
            nucleo.Inscrever(new SistemasDeLuz());
            nucleo.Inscrever(new PainelDENavegacao());
            nucleo.Inscrever(new Escudo());
            
            // Dicionário compartilhado entre as chamadas ao MenuTripulacao,
            // guarda os tripulantes criados durante toda a execução do programa,
            var tripulantes = new Dictionary<string, Tripulantes>();

            // Nave Client do padrão Decorator começa sem nenhuma arma equipada.
            var nave = new Nave();
            
            // Menu para o jogador selecionar qual opção ele dejesa acessar da nave
            while (true)
            {
                Console.WriteLine("=== Simulador do Laboratório ===");
                Console.WriteLine("1 - Núcleo da Nave");
                Console.WriteLine("2 - Tripulação e Funções");
                Console.WriteLine("3 - Armamento");
                Console.WriteLine("0 - Sair");
                Console.Write("> ");
                string? opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        MenuNucleo.Executar(nucleo);
                        break;

                    case "2":
                        MenuTripulacao.Executar(tripulantes);
                        break;

                    case "3":
                        MenuArmamento.Executar(nave);
                        break;

                    case "0":
                        Console.WriteLine("Encerrando...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
