namespace SpaceshipLab.Arsenal.Modificadores
{
    /// <summary>
    /// É o Decorator abstrato ao mesmo tempo que implementa IArma, guarda uma referência a outra IArma 
    /// é essa referência que permite empilhar modificadores um dentro do outro
    /// </summary>
    /// <remarks>
    /// Padrão de projeto Decorator. Esta classe representa o papel de Decorator,
    /// embrulha um IArma existente e delega a ele antes ou depois de adicionar seu próprio comportamento.
    /// </remarks>
    public abstract class ModificadorArma : IArma
    {

        protected readonly IArma arma;

        // E o construtor que recebe a arma ou outro modificador que está sendo embrulhado, guarda na referência interna
        protected ModificadorArma(IArma arma)
        {
            this.arma = arma;
        }

        /// A classe base não implementa, obriga cada modificador concreto a fazer isso via override 
        public abstract string Descricao { get; }
        public abstract int Dano { get; }
        public abstract void Atirar();
    }
}