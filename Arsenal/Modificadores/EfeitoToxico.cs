namespace SpaceshipLab.Arsenal.Modificadores
{

    /// <summary>
    /// E uma classe ConcreteDecorators que segue as normas propostas pela ModificadorArma.
    /// Responsavel por adicionar efeito toxíco aos disparos das armas.
    /// </summary>
    public class EfeitoToxico : ModificadorArma
    {
        public EfeitoToxico(IArma arma) : base(arma) { }

        //Pega a descrição de dentro (arma.Descricao) e acrescenta o próprio efeito
        public override string Descricao => $"{arma.Descricao} + Efeito toxico";

        //Pega o dano de dentro (arma.Dano) e soma o próprio valor extra
        public override int Dano => arma.Dano + 4;

        //Chama arma.Atirar() primeiro, só depois imprime seu próprio efeito,
        // essa ordem é o que cria o efeito de cascata quando tem vários modificadores empilhados

        public override void Atirar()
        {
            arma.Atirar();
            Console.WriteLine("[Modificador] Aplicando efeiro toxico adicional (+4, corroe armadura).");
        }
    }
}