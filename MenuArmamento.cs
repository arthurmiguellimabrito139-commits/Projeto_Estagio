using System;
using SpaceshipLab.Arsenal;
using SpaceshipLab.Arsenal.Armas;
using SpaceshipLab.Arsenal.Modificadores;

namespace SpaceshipLab
{
    /// <summary>
    /// Essa classe é quem liga os comandos digitados ao console às e ações reais da Nave e das armas e modificadores.
    ///</summary>
    public static class MenuArmamento
    {
        /// <summary>
        /// Recebe a Nave já criada compartilhada com o Programa.cs
        /// Mostra o menu de comandos e entra num loop lendo linha por linha do console,
        /// separa a linha em comando + argumentos, e decide qual ação disparar.
        /// </summary>
        public static void Executar(Nave nave)
        {
            Console.WriteLine("--- Armamento da Nave ---");
            Console.WriteLine("Comandos: equipar_arma <tipo> | adicionar_modificador <tipo> | atirar | voltar");
            Console.WriteLine("Armas disponíveis: laser, misseis, canhao_de_fotóns");
            Console.WriteLine("Modificadores disponíveis: dano_fogo, perfuração, toxico, paralisia");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Comandos> ");
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
                        case "equipar_arma":
                            nave.EquiparArma(CriarArma(partes[1]));
                            break;

                        case "adicionar_modificador":
                            AdicionarModificador(nave, partes[1]);
                            break;

                        case "atirar":
                            nave.Atirar();
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
        /// Recebe um texto digitado pelo jogador (ex: "laser", "misseis").
        /// Devolve a instância de IArma (ConcreteComponent) correspondente a esse texto.
        /// Traduz o comando digitado no console pra uma arma base concreta.
        /// Se o texto não corresponder a nenhuma arma conhecida, lança uma exceção.
        /// </summary>
        private static IArma CriarArma(string tipo)
        {
            switch (tipo)
            {
                case "laser":
                    return new Laser();
                case "misseis":
                    return new EnxameMisseis();
                case "canhao_de_fotóns":
                    return new CanhaoDeFotons();
                default:
                    throw new ArgumentException($"Tipo de arma desconhecido: '{tipo}'");
            }
        }

        /// <summary>
        /// Recebe a Nave e um texto digitado pelo jogador (ex: "fogo", "paralisia").
        /// Traduz o texto pra uma instrução de criação e manda pra Nave.AdicionarModificador, 
        /// que é quem de fato embrulha a arma atual com o Decorator escolhido. 
        /// Se o texto não corresponder a nenhum modificador conhecido, só avisa no console, sem lançar exceção.
        /// </summary>
        private static void AdicionarModificador(Nave nave, string tipo)
        {
            switch (tipo)
            {
                case "dano_fogo":
                    nave.AdicionarModificador(arma => new DanoFogo(arma));
                    break;

                case "perfuração":
                    nave.AdicionarModificador(arma => new PerfuracaoBlindagem(arma));
                    break;

                case "toxico":
                    nave.AdicionarModificador(arma => new EfeitoToxico(arma));
                    break;

                case "paralisia":
                    nave.AdicionarModificador(arma => new Paralisia(arma));
                    break;
                default:
                    Console.WriteLine($"Modificador desconhecido: '{tipo}'");
                    break;
            }
        }
    }
}
