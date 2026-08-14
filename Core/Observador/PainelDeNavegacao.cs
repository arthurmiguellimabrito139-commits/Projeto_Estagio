namespace SpaceshipLab.Core.Observador
{    
    /// <summary>
    /// Painel de navegação da nave.
    /// </summary>
    /// <remarks>
    /// Representa um ConcreteObserver que reage
    /// ao status do NucleoNave sem que o núcleo saiba de sua existência.
    /// Seguindo o contrato com a interface IObservadorNucleo
    /// </remarks>
    
    public class PainelDENavegacao : IObservadorNucleo
    {
        
        // Recebe o status e a energia atuais.
        // Imprime uma mensagem diferente dependendo se o status é
        // Critico ele reduz o consumo do painel, mas se for normal o painel opera em 100%.
        public void StatusMudar(StatusNucleo status, int energiaAtual)
        {
            if (status == StatusNucleo.Critico)
            {
                Console.WriteLine($"Painel de navegação: Reduzindo consumo do painel! Energia em estado crítico: {energiaAtual}%.");
            }
            else
            {
                Console.WriteLine($"Painel de navegação: Sistemas de navegação operando a 100%.");
            }
        }
    }
}