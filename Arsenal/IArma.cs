namespace SpaceshipLab.Arsenal
{
    /// <summary>
    /// E a inteface, o contrato comum que tanto as armas base quanto os modificadores precisam seguir tendo uma descrição e a quantidade de dano,
    /// além de realizar o disparo.
    /// </summary>
    /// <remarks>
    /// Padrão de projeto Decorator. Esta interface representa o papel de Component,
    /// tanto ConcreteComponents (Laser, EnxameMisseis) quanto Decorators (ModificadorArma
    /// e suas subclasses) implementam ela, permitindo que sejam tratados de forma uniforme.
    /// </remarks>
    public interface IArma
    {
        string Descricao
        {
            get;
        }
        int Dano
        {
            get;
        }

        // executa a ação de disparo
        void Atirar();
    }
}