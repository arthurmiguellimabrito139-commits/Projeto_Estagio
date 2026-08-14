using System;

// E uma classe concreta que implementa a interface IFuncaoTripulante e obedece as Normas dela.

namespace SpaceshipLab.Crew.tripulante {

    /// A classe FuncaoCozinheiro foi criada para o tripulante receber a função de cozinheiro da nave.
    public class FuncaoConzinheiro : IFuncaoTripulante 
    {
        public string NomeFuncao => "Conzinheiro";

    /// A função ExecutarTarefa recebe o nome do tripulante que está executando a tarefa e imprime uma mensagem referente a função.
        public void ExecutarTarefa(string nomeTripulante) {
            Console.WriteLine($"[Cozinha] {nomeTripulante} assumiu a conzinha da nave!");
       }
    }
}