# SpaceshipLab — Desafio Técnico LabTIME

Simulador em console das mecânicas de uma nave espacial, desenvolvido para o desafio técnico de estágio da LabTIME. O projeto implementa três Padrões de Projeto (Observer, State e Decorator), cada um resolvendo uma das restrições arquiteturais propostas no briefing.

---

## 1. Mapeamento e Justificativa

### Ticket 1 — Sistema de Contingência do Núcleo → **Observer**

**Requisito:** ao atingir energia crítica, o núcleo precisa avisar Escudos, Luzes e Painéis de Navegação, e a estrutura deve permitir adicionar novos sistemas reagindo no futuro sem alterar o núcleo.

**Por que Observer:** o padrão inverte a dependência, em vez do núcleo conhecer cada sistema por nome e chamar seus métodos diretamente, ele conhece só uma lista de observadores genéricos (`IObservadorNucleo`) e notifica todos quando o status muda. Isso cumpre exatamente a restrição do ticket: um sistema novo (ex: Suporte de Vida) só precisa implementar a interface e se inscrever — zero alteração dentro da classe `NucleoNave`.

### Ticket 2 — Comportamento Dinâmico da Tripulação → **State**

**Requisito:** trocar a função de um NPC vivo em tempo real, sem destruir o objeto e sem blocos de if/else ou switch decidindo o comportamento.

**Por que State:** Cada função (Canhoneiro, Piloto, Mecânico, etc.) vira sua própria classe, todas implementando o mesmo contrato (`IFuncaoTripulante`). O tripulante (`Tripulantes`) não decide como trabalhar — ele só guarda uma referência para a função atual e delega. Trocar de função é apenas trocar essa referência por outro objeto, sem destruir nem recriar o tripulante, e sem nenhum if/else decidindo comportamento.

**Alternativa considerada e descartada:** inicialmente cogitei usar Factory Method para a criação das funções por já ter feito um trabalho em POO uasando o metodo. Porém, Factory Method resolve bem o "como funciona" cada tipo de função, mas não resolve sozinho o problema central do ticket: trocar o comportamento de um tripulante "já existente" sem destruí-lo. Uma solução baseada só em Factory levaria a recriar o objeto `Tripulantes` inteiro a cada troca de função, o que violaria diretamente a restrição do briefing. Ja o State resolve isso separando a identidade do tripulante do comportamento atual.

### Ticket 3 — Armamento Modular e Modificadores → **Decorator**

**Requisito:** a nave deve emitir apenas o comando genérico de atirar, sem conhecer a física de cada arma, e os modificadores devem se empilhar dinamicamente sem gerar uma classe nova para cada combinação possível.

**Por que Decorator:** Tanto as armas base quanto os modificadores implementam a mesma interface (`IArma`). Um modificador que "embrulha" outra arma e guarda uma referência para ela, ao disparar, primeiro deixa a arma interna atirar e depois soma seu próprio efeito. Isso permite empilhar camadas (ex: Laser + Dano de Fogo + Perfuração de Blindagem) sem nunca criar uma classe para cada combinação, a composição acontece em tempo de execução.

---

## 2. Identificação dos Papéis no Código

### Ticket 1 — Observer (`SpaceshipLab.Core` / `SpaceshipLab.Core.Observador`)

| Papel do padrão | Classe/Interface |
|---|---|
| Subject | `NucleoNave` |
| Observer (interface) | `IObservadorNucleo` |
| ConcreteObserver | `SistemasDeLuz`, `PainelDENavegacao`, `Escudo` |

`NucleoNave` mantém a lista de `IObservadorNucleo` e chama `StatusMudar` em cada um sempre que o status (`StatusNucleo`) muda de fato, sem conhecer as classes concretas.

### Ticket 2 — State (`SpaceshipLab.Crew` / `SpaceshipLab.Crew.tripulante`)

| Papel do padrão | Classe/Interface |
|---|---|
| State (interface) | `IFuncaoTripulante` |
| ConcreteState | `FuncaoCanhoneiro`, `FuncaoPiloto`, `FuncaoConzinheiro`, `FuncaoMecanico`, `FuncaoZelador`, `FuncaoDesocupado` |
| Context | `Tripulantes` |

`Tripulantes` guarda a referência `FuncaoAtual` (do tipo `IFuncaoTripulante`) e delega toda a lógica de comportamento a ela através de `Trabalhar()`. `TrocarFuncao()` apenas substitui essa referência, nunca destrói o objeto `Tripulantes`.

### Ticket 3 — Decorator (`SpaceshipLab.Arsenal` / `SpaceshipLab.Arsenal.Armas` / `SpaceshipLab.Arsenal.Modificadores`)

| Papel do padrão | Classe/Interface |
|---|---|
| Component | `IArma` |
| ConcreteComponent | `Laser`, `EnxameMisseis`, `CanhaoDeFotons` |
| Decorator (abstrato) | `ModificadorArma` |
| ConcreteDecorator | `DanoFogo`, `PerfuracaoBlindagem`, `EfeitoToxico`, `Paralisia` |
| Client | `Nave` |

`ModificadorArma` implementa `IArma` e ao mesmo tempo guarda uma referência a outra `IArma` — é essa dupla característica que permite empilhar decorators um dentro do outro. `Nave` só conhece `IArma`, nunca sabendo se por baixo existem 0, 1 ou vários modificadores aplicados.

---

## 3. Instruções de Execução

### Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior instalado
- Confirme a instalação com:
  ```bash
  dotnet --version
  ```

### Clonar o repositório

```bash
git clone https://github.com/arthurmiguellimabrito139-commits/Projeto_Estagio.git
cd Projeto_Estagio/SpaceshipLab
```

### Compilar

```bash
dotnet build
```

### Executar

```bash
dotnet run
```

### Usando o simulador

Ao rodar, o programa mostra um menu principal com três submenus:

```
1 - Núcleo da Nave
2 - Tripulação e Funções
3 - Armamento
0 - Sair
```

**Submenu 1 — Núcleo (Observer):**
```
tomar_dano <n>
reduzir_energia <n>
regenerar_energia <n>
voltar
```
Exemplo: `tomar_dano 80` reduz a energia abaixo do limite crítico e dispara automaticamente a reação dos três sistemas observadores (Luzes, Painel, Escudo).

**Submenu 2 — Tripulação (State):**
```
trocar_funcao <nome> <funcao>
trabalhar <nome>
matar <nome>
listar
voltar
```
Funções disponíveis: `canhoneiro`, `piloto`, `cozinheiro`, `mecanico`, `zelador`, `desocupado`.
Um tripulante é criado automaticamente (com função sorteada) na primeira vez que seu nome é mencionado em qualquer comando.

**Submenu 3 — Armamento (Decorator):**
```
equipar_arma <tipo>
adicionar_modificador <tipo>
atirar
voltar
```
Armas disponíveis: `laser`, `misseis`, `canhao_de_fotóns`.
Modificadores disponíveis: `dano_fogo`, `perfuração`, `toxico`, `paralisia`.
Exemplo: `equipar_arma laser` → `adicionar_modificador dano_fogo` → `adicionar_modificador perfuração` → `atirar` mostra o efeito em cascata dos modificadores empilhados.

Todos os três submenus tratam entradas inválidas (comando incompleto ou argumento inválido) sem encerrar o programa, retornando ao prompt do submenu.

---

## Ideias de Melhoria Futura

Algumas extensões que ficaram fora do escopo do desafio, mas que fariam sentido numa próxima iteração:

- **Eficiência dos tripulantes:** tripulantes fora de sua função (ex: um Piloto forçado a trabalhar como Mecânico) teriam eficiência reduzida na tarefa. Isso poderia impactar o consumo de energia da nave — uma tripulação mal alocada aumentaria o gasto do núcleo, criando uma ligação direta entre os Tickets 1 e 2.
- Comando para consultar o histórico de modificadores aplicados a uma arma, sem precisar disparar.
- Persistência do estado da simulação entre execuções (salvar/carregar).

## Estrutura do Projeto

```
SpaceshipLab/
  Programa.cs
  MenuNucleo.cs
  MenuTripulacao.cs
  MenuArmamento.cs
  Core/
    StatusNucleo.cs
    ObservadorNucleo.cs
    NucleoNave.cs
    Observador/
      SistemasDeLuz.cs
      PainelDeNavegacao.cs
      Escudo.cs
  Crew/
    IFuncaoTripulante.cs
    Tripulantes.cs
    tripulante/
      FuncaoCanhoneiro.cs
      FuncaoPiloto.cs
      FuncaoConzinheiro.cs
      FuncaoMecanico.cs
      FuncaoZelador.cs
      FuncaoDesocupado.cs
  Arsenal/
    IArma.cs
    Nave.cs
    Armas/
      Laser.cs
      EnxameMisseis.cs
      CanhaoDeFotons.cs
    Modificadores/
      ModificadorArma.cs
      DanoFogo.cs
      PerfuracaoBlindagem.cs
      EfeitoToxico.cs
      Paralisia.cs
```
