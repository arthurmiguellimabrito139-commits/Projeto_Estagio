namespace SpaceshipLab.Arsenal.Armas
{

    /// É o ConcreteComponent, a base da cascata de decorators.
    /// Descricao e Dano têm valores fixos, específicos de cada arma.
    /// Responsável por atirar fotóns.

    public class CanhaoDeFotons : IArma
    {
        public string Descricao => "Canhão de Fotóns";
        public int Dano => 15;

        //Atirar(): imprime a mensagem de disparo
        public void Atirar()
        {
            Console.WriteLine($"[Arma] {Descricao} disparado! Dano: {Dano}.");
        }
    }
}