using System;

// E uma classe concreta que implementa a interface IFuncaoTripulante e obedece as Normas dela.

namespace SpaceshipLab.Crew.tripulante {
    
    /// A classe FuncaoMecanico foi criada para o tripulante receber a função de mecanico da nave.
    public class FuncaoMecanico : IFuncaoTripulante 
    {
        public string NomeFuncao => "Mecanico";

    /// A função ExecutarTarefa recebe o nome do tripulante que está executando a tarefa e imprime uma mensagem referente a função.
        public void ExecutarTarefa(string nomeTripulante) {
            Console.WriteLine($"[Mecanico] {nomeTripulante} assumiu o posto e está operando como um mecanico!");
       }
    }
}
