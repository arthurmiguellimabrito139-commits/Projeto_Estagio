using System;

// E uma classe concreta que implementa a interface IFuncaoTripulante e obedece as Normas dela.

namespace SpaceshipLab.Crew.tripulante {

    /// A classe FuncaoPiloto foi criada para o tripulante receber a função de piloto da nave.
    public class FuncaoPiloto : IFuncaoTripulante 
    {
        public string NomeFuncao => "Piloto";
 
    /// A função ExecutarTarefa recebe o nome do tripulante que está executando a tarefa e imprime uma mensagem referente a função.
        public void ExecutarTarefa(string nomeTripulante)
        {
            Console.WriteLine($"[Ponte de Comando] {nomeTripulante} assumiu o posto de piloto da nave!");
       }
    }
}