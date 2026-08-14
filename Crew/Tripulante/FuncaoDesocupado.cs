using System;

// E uma classe concreta que implementa a interface IFuncaoTripulante e obedece as Normas dela.

namespace SpaceshipLab.Crew.tripulante {
     
     /// A classe FuncaoDesocupado foi criada para caso o jogador queira tirar a funçao de um tripulante, o deixando desocupado.
    public class FuncaoDesocupado : IFuncaoTripulante
    {
        public string NomeFuncao => "Desocupado";

    /// A função ExecutarTarefa recebe o nome do tripulante que está executando a tarefa e imprime uma mensagem referente a função.
        public void ExecutarTarefa(string nomeTripulante) {
            Console.WriteLine($"{nomeTripulante} está sem função no momento, aguardando ordens.");
        }
    }
}