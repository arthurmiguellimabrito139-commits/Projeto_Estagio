namespace SpaceshipLab.Core.Observador
{   
    /// <summary>
    /// Escudo da nave
    /// </summary>
    /// <remarks>
    /// Representa um ConcreteObserver que reage
    /// ao status do NucleoNave sem que o núcleo saiba de sua existência.
    /// Seguindo o contrato com a interface IObservadorNucleo
    /// </remarks>
    public class Escudo : IObservadorNucleo
    {   
        // Muda o foco de defesa pra modo de sobrevivência em crise,
        // ou volta ao foco padrão quando normalizado.
        // Recebendo a energia atual da nucleo e seus Status. 
        public void StatusMudar(StatusNucleo status, int energiaAtual)
        {
            if (status == StatusNucleo.Critico)
            {
                Console.WriteLine($"Escudos: Mudando foco de defesa para modo de sobrevivência! Energia em {energiaAtual}%.");
            }
            else
            {
                Console.WriteLine($"Escudos: Voltando ao foco de defesa padrão. Energia em {energiaAtual}%.");
            }
        }
    }
}