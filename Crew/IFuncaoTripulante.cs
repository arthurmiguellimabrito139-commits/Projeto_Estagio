namespace SpaceshipLab.Crew
{
    /// <summary>
    /// Esta e a interface, que funciona como um contrato definindo a forma que qualquer estado precisa ter.
    /// Essa interface define que toda classe que for uma função de tripulação precisa ter esses dois membros:
    /// NomeFunçao e ExecutarTarefa
    /// </summary>
    /// <remarks>
    /// Esse ticket utiliza o padrão State.
    /// cada implementação concreta (FuncaoCanhoneiro, FuncaoMecanico, etc.) é
    /// um estado que define o comportamento de ExecutarTarefa de forma isolada.
    /// </remarks>
    public interface IFuncaoTripulante
    {
        string NomeFuncao
        {
            get;
        }

        //A função ExecutarTarefa recebe o nome do tripulante que está executando a tarefa e imprime oque ele esta fazendo
        void ExecutarTarefa(string nomeTripulante);
    }
}