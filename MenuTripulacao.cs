using System;
using System.Collections.Generic;
using SpaceshipLab.Crew;
using SpaceshipLab.Crew.tripulante;

namespace SpaceshipLab
{
    /// <summary>
    /// E chamada pelo arquivo Programa.cs como menu auxiliar para acessar as ações reais dos Tripulante e das suas funções.
    /// </summary>
    public static class MenuTripulacao
    {
        // Criado uma única vez como campo estático, pra não sortear o mesmo
        // número toda vez que uma instância nova de Random for criada muito perto no tempo.
        private static readonly Random rng = new Random();

        /// <summary>
        /// Mostra o menu de comandos, entra num loop lendo linha por linha do console,
        /// separa a linha em comando + argumentos, e decide qual ação disparar.
        /// </summary>
        public static void Executar(Dictionary<string, Tripulantes> tripulantes)
        {
            Console.WriteLine("--- Tripulação e Funções ---");
            Console.WriteLine("Comandos: trocar_funcao <nome> <funcao> | trabalhar <nome> | matar <nome> | listar | voltar");
            Console.WriteLine("Funções disponíveis: canhoneiro, piloto, cozinheiro, mecanico, zelador, desocupado");
            Console.WriteLine();

            while (true)
            {
                Console.Write("tripulacao: comandos> ");
                string? linha = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue;
                }

                string[] partes = linha.Trim().Split(' ');
                string comando = partes[0];

                try
                {
                    switch (comando)
                    {
                        case "trocar_funcao":
                            {
                                var membro = ObterOuCriarTripulante(tripulantes, partes[1]);
                                membro.TrocarFuncao(CriarFuncao(partes[2]));
                                break;
                            }

                        case "trabalhar":
                            {
                                var membro = ObterOuCriarTripulante(tripulantes, partes[1]);
                                membro.Trabalhar();
                                break;
                            }

                        case "matar":
                            {
                                var membro = ObterOuCriarTripulante(tripulantes, partes[1]);
                                membro.Matar();
                                break;
                            }

                        case "listar":
                            foreach (var item in tripulantes)
                            {
                                var t = item.Value;
                                Console.WriteLine($"{t.Nome} - {t.FuncaoAtual.NomeFuncao} - {(t.EstaVivo ? "vivo" : "morto")}");
                            }
                            break;

                        case "voltar":
                            Console.WriteLine();
                            return;

                        default:
                            Console.WriteLine($"Comando desconhecido: '{comando}'");
                            break;
                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine($"Comando inválido: {erro.Message}");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Recebe o dicionário de tripulantes e o nome digitado pelo jogador.
        /// Devolve o Tripulante correspondente àquele nome.
        /// Se o nome ainda não existe no dicionário, cria um Tripulante novo escolhendo uma função 
        /// aleatoriamente e adiciona no dicionário;
        /// se já existe, só devolve o que já estava lá. É esse método que permite
        /// o jogador criar um Tripulante simplesmente mencionando o nome pela primeira vez,
        /// sem precisar de um comando separado.
        /// </summary>
        private static Tripulantes ObterOuCriarTripulante(Dictionary<string, Tripulantes> tripulantes, string nome)
        {
            if (!tripulantes.ContainsKey(nome))
            {
                tripulantes[nome] = new Tripulantes(nome, FuncaoAleatoria());
                Console.WriteLine($"Novo tripulante '{nome}' criado com função sorteada: {tripulantes[nome].FuncaoAtual.NomeFuncao}");
            }

            return tripulantes[nome];
        }

        /// <summary>
        /// Devolve uma IFuncaoTripulante sorteada entre as funções de trabalho
        /// Desocupado não entra no sorteio pois na minha opinião nao faria sentido um tripulante ter sua função inicial como desocupado,
        /// </summary>
        private static IFuncaoTripulante FuncaoAleatoria()
        {
            int escolha = rng.Next(5); // sorteia um número de 0 a 4

            switch (escolha)
            {
                case 0: return new FuncaoCanhoneiro();
                case 1: return new FuncaoPiloto();
                case 2: return new FuncaoConzinheiro();
                case 3: return new FuncaoMecanico();
                default: return new FuncaoZelador();
            }
        }

        /// <summary>
        /// Recebe um texto digitado pelo jogador (ex: "canhoneiro", "piloto").
        /// Devolve a instância de IFuncaoTripulante correspondente a esse texto.
        /// Traduz o comando digitado no console pra um objeto concreto de função.
        /// Se o texto não corresponder a nenhuma função conhecida, lança uma
        /// exceção.
        /// </summary>
        private static IFuncaoTripulante CriarFuncao(string tipo)
        {
            switch (tipo)
            {
                case "canhoneiro":
                    return new FuncaoCanhoneiro();
                case "piloto":
                    return new FuncaoPiloto();
                case "cozinheiro":
                    return new FuncaoConzinheiro();
                case "mecanico":
                    return new FuncaoMecanico();
                case "zelador":
                    return new FuncaoZelador();
                case "desocupado":
                    return new FuncaoDesocupado();
                default:
                    throw new ArgumentException($"Função desconhecida: '{tipo}'");
            }
        }
    }
}