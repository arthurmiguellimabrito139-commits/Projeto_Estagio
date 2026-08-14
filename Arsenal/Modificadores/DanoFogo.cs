namespace SpaceshipLab.Arsenal.Modificadores
{

    /// <summary>
    /// E uma classe ConcreteDecorators que segue as normas propostas pela ModificadorArma.
    /// Responsavel por adicionar um dano flamejantes aos disparos das armas.
    /// </summary>
    public class DanoFogo : ModificadorArma
    {
        public DanoFogo(IArma arma) : base(arma) { }

        // Pega a descrição de dentro (arma.Descricao) e acrescenta o próprio efeito
        public override string Descricao => $"{arma.Descricao} + Dano de Fogo";

        //Pega o dano de dentro (arma.Dano) e soma o próprio valor extra
        public override int Dano => arma.Dano + 5;

        //Chama arma.Atirar() primeiro, só depois imprime seu próprio efeito,

        public override void Atirar()
        {
            arma.Atirar();
            Console.WriteLine("[Modificador] Aplicando Dano de Fogo adicional (+5).");
        }
    }
}