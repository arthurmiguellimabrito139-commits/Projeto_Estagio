namespace SpaceshipLab.Core
{   

     /// <summary>
    /// É a interface, o contrato que qualquer sistema da nave precisa seguir
    /// pra poder ouvir mudanças no núcleo, sem que o núcleo precise
    /// conhecer esse sistema por nome.
    /// </summary>
    /// <remarks>
    /// Usando o padrão de projeto Observer. Cada sistema concreto como SistemasDeLuz, PainelDENavegacao e 
    /// Escudo implementa está interface para se inscrever e reagir a mudanças no
    /// NucleoNave, sem o núcleo conhecer a implementação de cada um.
    /// </remarks>
    public interface IObservadorNucleo
    {   
        // Recebe o novo status e o nível de energia atual; não devolve nada.
        // É chamado automaticamente pelo NucleoNave sempre que o status muda.

        void StatusMudar(StatusNucleo status, int energiaAtual);
    }
}