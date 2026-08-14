namespace SpaceshipLab.Core.Observador
{
    /// <summary>
    /// Sistema de iluminação da nave.
    /// </summary>
    /// <remarks>
    /// Representa um ConcreteObserver que reage
    /// ao status do NucleoNave sem que o núcleo saiba de sua existência.
    /// Seguindo o contrato com a interface IObservadorNucleo
    /// </remarks>
    public class SistemasDeLuz : IObservadorNucleo
    {

        // Recebe o status e a energia atuais.
        // Imprime uma mensagem diferente dependendo se o status é
        // Critico ele apaga as luzes mas se for normal então ele restaura a ikuminação da nave.
        public void StatusMudar(StatusNucleo status, int energiaAtual)
        {
            if (status == StatusNucleo.Critico)
            {
                Console.WriteLine($"Luzes apagadas, deviso a energia esta em {energiaAtual}%.");
            }
            else
            {
                Console.WriteLine($"Luzes acessas, iluminação normal restaurada. Energia em {energiaAtual}%.");
            }
        }
    }

}