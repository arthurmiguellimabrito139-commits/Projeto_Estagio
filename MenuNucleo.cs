using System;
using SpaceshipLab.Core;

namespace SpaceshipLab
{

    /// <summary>
    /// E quem liga os comandos funcionado como menu, pegando os dados
    /// digitados no console e transformando em ações reais do NucleoNave.
    /// </summary>
    public static class MenuNucleo
    {
        /// <summary>
        /// Recebe o NucleoNave já criado compartilhado com o Programa.cs.
        /// Mostra o menu de comandos, entra num loop lendo linha por linha do
        /// console, separa a linha em comando + argumentos, e decide qual ação
        /// disparar e depois de cada comando, mostra a energia atual do núcleo.
        /// </summary>
        public static void Executar(NucleoNave nucleo)
        {
            Console.WriteLine("--- Núcleo da Nave ---");
            Console.WriteLine("Comandos: tomar_dano <n> | reduzir_energia <n> | regenerar_energia <n> | voltar");
            Console.WriteLine();


            while (true)
            {
                Console.Write("nucleo: Comandos> ");
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
                        case "tomar_dano":
                            nucleo.TomarDano(int.Parse(partes[1]));
                            break;

                        case "reduzir_energia":
                            nucleo.ReduzirEnergia(int.Parse(partes[1]));
                            break;

                        case "regenerar_energia":
                            nucleo.RegenerarEnergia(int.Parse(partes[1]));
                            break;

                        case "voltar":
                            Console.WriteLine();
                            return;

                        default:
                            Console.WriteLine($"Comando desconhecido: '{comando}'");
                            break;
                    }

                    Console.WriteLine($"[Núcleo] Energia atual: {nucleo.Energia}%");
                }
                catch (Exception erro)
                {
                    Console.WriteLine($"Comando inválido: {erro.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}