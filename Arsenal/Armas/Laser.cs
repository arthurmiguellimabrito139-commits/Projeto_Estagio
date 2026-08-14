namespace SpaceshipLab.Arsenal.Armas {
     
   /// É o ConcreteComponent, a base da cascata de decorators.
   /// Descricao e Dano têm valores fixos, específicos de cada arma.
   /// Responsável por atirar um raio laser.
    public class Laser : IArma {
        public string Descricao => "Laser";
        public int Dano => 20;
        
      //Atirar(): imprime a mensagem de disparo
        public void Atirar() {
            Console.WriteLine($"[Arma] {Descricao} disparado! Dano: {Dano}.");
        }
    }
}