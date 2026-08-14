namespace SpaceshipLab.Arsenal.Armas
{

    /// É o ConcreteComponent, a base da cascata de decorators.
    /// Descricao e Dano têm valores fixos, específicos de cada arma.
    /// Responsável por atirar um Enxame de Mísseis.
    public class EnxameMisseis : IArma
    {
        public string Descricao => "Enxame de Mísseis";
        public int Dano => 25;

        //Atirar(): imprime a mensagem de disparo
        public void Atirar()
        {
            Console.WriteLine($"[Arma] {Descricao} disparado! Dano: {Dano}.");
        }
    }
}