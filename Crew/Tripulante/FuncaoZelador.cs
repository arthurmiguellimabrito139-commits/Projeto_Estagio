using System;

// E uma classe concreta que implementa a interface IFuncaoTripulante e obedece as Normas dela.

namespace SpaceshipLab.Crew.tripulante
{

    /// A classe FuncaoZelador foi criada para o tripulante receber a função de zelador da nave.
    public class FuncaoZelador : IFuncaoTripulante
    {
        public string NomeFuncao => "Zelador";

        /// A função ExecutarTarefa recebe o nome do tripulante que está executando a tarefa e imprime uma mensagem referente a função.
        public void ExecutarTarefa(string nomeTripulante)
        {
            Console.WriteLine($"[Limpeza] {nomeTripulante} assumiu a Limpeza da nave!");
        }
    }
}