using System;

namespace SpaceshipLab.Crew {

 /// <summary>
 /// Essa classe epresenta um tripulante individual da tripulação. 
 /// Guarda referência pra sua função atual e delega o comportamento a ele(a), sem decidir nada sozinha.
 /// E atua como o contexto do padão State, nao trabalha, mas mantém uma referência ao estado atual.
 /// </summary>

    public class Tripulantes {
     
     // Não recebe nada, só guarda e devolve o nome do tripulante.
        public string Nome { 
            get; 
            private set; 
            
        }

       // Não recebe nada, guarda e devolve a referência pra função atual da tripulação
        public IFuncaoTripulante FuncaoAtual { 
            get; 
            private set; 
        }

          //Não recebe nada, guarda e devolve se o tripulante pode agir ou não verificando se ele está vivo.
        public bool EstaVivo { 
            get; 
            private set; 
            } = true;
        
        // Recebe o nome do tripulante e qual função ele já começa exercendo, inicializa Nome e FuncaoAtual com esses valores, e EstaVivo já começa true por padrão.
        public Tripulantes(string nome, IFuncaoTripulante funcaoInicial) {
            Nome = nome;
            FuncaoAtual = funcaoInicial;
        }
        
        // Recebe a nova função que o tripulante vai assumir. 
        // Primeiro checando se o tripulante está vivo, troca a referência pra nova função recebida, sem destruir o objeto
        // e se estiver morto solta um aviso no terminal.
        public void TrocarFuncao(IFuncaoTripulante novaFuncao) {
            if (!EstaVivo) {
                Console.WriteLine($"{Nome} está morto e não pode trocar de função.");
                return;
            } 

            Console.WriteLine($"{Nome} trocando função: {FuncaoAtual.NomeFuncao} -> {novaFuncao.NomeFuncao}");
            FuncaoAtual = novaFuncao;
        }
        
        // Checa se o tripulante está vivo, e se estiver, delega pra ele em sua função atual para Executar a tarefa.
        public void Trabalhar() {
            if (!EstaVivo) {
                Console.WriteLine($"{Nome} está morto e não pode trabalhar.");
                return;
            }

            FuncaoAtual.ExecutarTarefa(Nome);
        }
        
        // Caso o jogador queira matar algum tripulante esta função serve para isso,
        // mudando EstaVivo pra false e avisando no console sem destruir o objeto criado.

        public void Matar() {
            EstaVivo = false;
            Console.WriteLine($"{Nome} morreu.");
        }
    }
}