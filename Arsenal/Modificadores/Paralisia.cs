namespace SpaceshipLab.Arsenal.Modificadores
{

    /// <summary>
    /// E uma classe ConcreteDecorators que segue as normas propostas pela ModificadorArma.
    /// Responsavel por adicionar efeito paralisante aos tiros das armas.
    /// </summary>
    public class Paralisia : ModificadorArma
    {
        public Paralisia(IArma arma) : base(arma) { }

        // Pega a descrição de dentro (arma.Descricao) e acrescenta o próprio efeito
        public override string Descricao => $"{arma.Descricao} + Paralisia";
        //Pega o dano de dentro (arma.Dano) e soma o próprio valor extra
        public override int Dano => arma.Dano + 2;

        //chama arma.Atirar() primeiro, só depois imprime seu próprio efeito,
        // essa ordem é o que cria o efeito de cascata quando tem vários modificadores empilhados

        public override void Atirar()
        {
            arma.Atirar();
            Console.WriteLine("[Modificador] Aplicando efeito de paralisia na arma (+2).");
        }
    }
}