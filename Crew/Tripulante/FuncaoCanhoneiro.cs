using System;

// E uma classe concreta que implementa a interface IFuncaoTripulante e obedece as Normas dela.

namespace SpaceshipLab.Crew.tripulante {

    /// A classe FuncaoCanhoneiro foi criada para o tripulante receber a função de Canhoneiro da nave.
    public class FuncaoCanhoneiro : IFuncaoTripulante 
    {
        public string NomeFuncao => "Operador de Canhões";
 
    /// A função ExecutarTarefa recebe o nome do tripulante que está executando a tarefa e imprime uma mensagem referente a função.
        public void ExecutarTarefa(string nomeTripulante)
        {
            Console.WriteLine($"[Canhão] {nomeTripulante} assumiu o posto e está operando os canhões!");
       }
    }
}