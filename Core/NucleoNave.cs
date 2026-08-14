namespace SpaceshipLab.Core
{
    /// <summary>
    /// Representa o núcleo de energia da nave. Mantém a lista de observadores
    /// inscritos e os notifica quando seu status muda, sem conhecer suas
    /// implementações concretas.
    /// </summary>
    /// <remarks>
    /// Esta classe representa o papel de guarda uma lista de IObservadorNucleo genéricos e notifica
    /// todos eles sempre que o status muda de fato, sem precisar conhecer
    /// Escudo, SistemasDeLuz ou PainelDENavegacao por nome.
    /// </remarks>
    public class NucleoNave
    {
        // Energia abaixo desse valor faz o status virar Critico.
        private readonly int limiteCritico = 30;

        // Guarda e devolve o nível de energia atual.
        // Só a própria classe pode alterar (private set).
        public int Energia
        {
            get;
            private set;
        }

        // Guarda e devolve o status atual do núcleo.
        public StatusNucleo StatusAtual { get; private set; } = StatusNucleo.Normal;

        // Lista dos observadores inscritos, guardados só pela interface,
        // o núcleo nunca sabe o tipo concreto de cada um.
        private readonly List<IObservadorNucleo> observadores = new List<IObservadorNucleo>();

        // Recebe a energia inicial que por padrao eu decidi deixar 100 e inicializa Energia com esse valor.
        public NucleoNave(int energiaInicial = 100)
        {
            Energia = energiaInicial;
        }

        // Recebe a quantidade de dano, subtrai de Energia, e reavalia o status.
        public void TomarDano(int quantidadeDano)
        {
            Energia = Energia - quantidadeDano;
            AvaliarStatus();
        }

        // Recebe um observador e adiciona na lista interna, a partir
        // daí ele passa a ser notificado a cada mudança de status.
        public void Inscrever(IObservadorNucleo observador)
        {
            if (observador != null)
            {
                observadores.Add(observador);
            }
        }

        // Recebe um observador e remove da lista, para de ser notificado.
        public void Desinscrever(IObservadorNucleo observador)
        {
            if (observador != null)
            {
                observadores.Remove(observador);
            }
        }

        // Recebe a quantidade a reduzir, reaproveita a mesma lógica de
        // TomarDano, só que representando uma redução manual via console
        // em vez de dano de combate.
        public void ReduzirEnergia(int quantidade)
        {
            TomarDano(quantidade);
        }

        // Recebe a quantidade a restaurar, além de somar em Energia e reavalia o status.
        public void RegenerarEnergia(int qtd)
        {
            Energia += qtd;
            AvaliarStatus();
        }

        // Calcula se o novo status é
        // Normal ou Critico com base na energia atual, e só chama
        // Notificar() se o status de fato mudou, evita notificar toda
        // vez que qualquer coisa acontece.
        private void AvaliarStatus()
        {
            StatusNucleo novoStatus = (Energia <= limiteCritico) ? StatusNucleo.Critico : StatusNucleo.Normal;

            if (novoStatus == StatusAtual)
            {
                return;
            }
            StatusAtual = novoStatus;
            Notificar();
        }

        // Percorre todos os observadores inscritos e chama StatusMudar em cada um, 
        // passando o status e a energia atuais.
        private void Notificar()
        {
            var observadoresCopia = observadores.ToArray();

            for (int i = 0; i < observadoresCopia.Length; i++)
            {
                observadoresCopia[i].StatusMudar(StatusAtual, Energia);
            }
        }
    }
}