using System;

namespace SpaceshipLab.Arsenal
{
    /// <summary>
    /// Nave é quem consome a estrutura Decorator, sem saber como ela funciona por dentro
    /// </summary>
    public class Nave
    {

        public IArma? ArmaAtual { get; private set; }
        
        //Recebe uma arma nova, substitui ArmaAtual do zero
        public void EquiparArma(IArma arma)
        {
            ArmaAtual = arma;
            Console.WriteLine($"[Nave] Arma equipada: {arma.Descricao}");
        }
        
        //Recebe uma instrução de como criar um modificador (uma função), aplica ela em cima do ArmaAtual atual.
        public void AdicionarModificador(Func<IArma, IArma> criarModificador)
        {
            if (ArmaAtual == null)
            {
                Console.WriteLine("[Nave] Nenhuma arma equipada para modificar.");
                return;
            }

            ArmaAtual = criarModificador(ArmaAtual);
            Console.WriteLine($"[Nave] Modificador aplicado. Configuração atual: {ArmaAtual.Descricao}");
        }
         
        // Só delega pra ArmaAtual.Atirar(), sem entender quantas camadas existem por baixo
        public void Atirar()
        {
            if (ArmaAtual == null)
            {
                Console.WriteLine("[Nave] Comando de atirar ignorado: nenhuma arma equipada.");
                return;
            }

            Console.WriteLine("[Nave] Comando genérico: ATIRAR!");
            ArmaAtual.Atirar();
        }
    }
}