# ScriptsPlayer2D

Repositório com scripts de controle de **players 2D** para Unity: andar, pular,
animações e morte do personagem ao encostar em inimigos.

## Requisitos

- Unity 6 ou superior (usa `Rigidbody2D.linearVelocity`)
- Pacote **Input System** instalado (`com.unity.inputsystem`)
  - `Edit > Project Settings > Player > Active Input Handling > Input System (New)`

Todos os scripts leem o teclado diretamente via `Keyboard.current`, sem Input Actions.

## Controles

| Ação | Teclas |
| --- | --- |
| Andar para a esquerda | `A` ou `←` |
| Andar para a direita | `D` ou `→` |
| Pular | `Espaço`, `W` ou `↑` |

## Scripts

Escolha **um** script de movimento por player (`walkingJumpingPlayer`, `walkingPlayer`,
`jumpingPlayer` ou `walkingJumpingAnimator`). A classe `enemy.cs` funciona
apenas com `walkingJumpingPlayer` — ver [Limitações conhecidas](#limitações-conhecidas).

### `walkingJumpingPlayer.cs`

Classe `walkingJumpingPlayer`. Andar + pular, com virada do sprite.

| Propriedade | Tipo | Padrão | Descrição |
| --- | --- | --- | --- |
| `velocidade` | `float` | `5` | Velocidade de deslocamento horizontal |
| `forcaPulo` | `float` | `7` | Velocidade vertical aplicada no pulo |

**Como usar:**

1. Crie um GameObject 2D com `SpriteRenderer`, `Rigidbody2D` e um `Collider2D`.
2. Adicione o script `walkingJumpingPlayer` ao objeto.
3. Garanta que exista um chão com collider para o contato
   (o pulo só funciona quando `noChao` é verdadeiro).

> O sprite vira automaticamente conforme a direção do movimento (`flipX`).

### `walkingPlayer.cs`

Classe `walkingPlayer`. Apenas andar, com virada do sprite.

| Propriedade | Tipo | Padrão | Descrição |
| --- | --- | --- | --- |
| `velocidade` | `float` | `5` | Velocidade de deslocamento horizontal |

**Como usar:**

1. Crie um GameObject 2D com `SpriteRenderer` e `Rigidbody2D`.
2. Adicione o script `walkingPlayer` ao objeto.

### `jumpingPlayer.cs`

Classe `jumpingPlayer`. Apenas pular.

| Propriedade | Tipo | Padrão | Descrição |
| --- | --- | --- | --- |
| `forcaPulo` | `float` | `7` | Velocidade vertical aplicada no pulo |

**Como usar:**

1. Crie um GameObject 2D com `Rigidbody2D` e um `Collider2D`.
2. Adicione o script `jumpingPlayer` ao objeto.
3. Garanta que exista um chão com collider para o contato
   (o pulo só funciona quando `noChao` é verdadeiro).

### `walkingJumpingAnimator.cs`

Classe `Movimento`. Andar + pular + animações do `Animator`.

| Propriedade | Tipo | Padrão | Descrição |
| --- | --- | --- | --- |
| `velocidade` | `int` | `5` | Velocidade de deslocamento horizontal (serializada) |
| `peDoPersonagem` | `Transform` | — | Posição dos pés, usada para detectar o chão |
| `layerChao` | `LayerMask` | — | Camada considerada como chão |

**Parâmetros do `Animator`:**

| Parâmetro | Tipo | Efeito |
| --- | --- | --- |
| `movendo` | `bool` | `true` enquanto o personagem se move |
| `salto` | `bool` | `true` enquanto o personagem está no ar |

**Como usar:**

1. Crie um GameObject 2D com `SpriteRenderer`, `Rigidbody2D`, `Animator` e um `Collider2D`.
2. Adicione o script `walkingJumpingAnimator` ao objeto.
3. Crie um Empty como marcador dos pés e arraste para `peDoPersonagem`.
4. Configure `layerChao` com a camada do chão.
5. No `Animator`, crie as parâmetros `movendo` e `salto` (bool) e as transições.

### `enemy.cs`

Classe `enemy`. Mata o player ao encostar no inimigo: toca a animação `Dead`,
para o movimento e recarrega a cena `SampleScene` após 1 segundo.

**Como usar:**

1. Crie um GameObject 2D com um `Collider2D` (e `Rigidbody2D` se necessário).
2. Adicione o script `enemy` ao objeto.
3. Garanta que o player esteja marcado com a tag `Player` e tenha os componentes
   `Animator`, `Rigidbody2D` e `walkingJumpingPlayer`.
4. No `Animator` do player, crie o trigger `Dead` e o bool `salto`.
5. Coloque a cena `SampleScene` em `File > Build Settings` para o reload funcionar.

> Limitação atual: o inimigo mata o player em qualquer direção do contato
> (não distingue pisar em cima de encostar de lado).

## Estrutura

```
ScriptsPlayer2D/
├── walkingJumpingPlayer.cs
├── walkingJumpingAnimator.cs
├── walkingPlayer.cs
├── jumpingPlayer.cs
└── enemy.cs
```

## Limitações conhecidas

- `enemy.cs` usa `GetComponent<walkingJumpingPlayer>()`. O player precisa usar
  exatamente esse script; com `walkingPlayer`, `jumpingPlayer` ou `walkingJumpingAnimator`
  o `enemy.cs` lança `NullReferenceException` ao chamar `movPlayer.enabled = false`.
- O script de movimento deve estar **no mesmo GameObject** que a tag `Player`,
  porque a busca de componentes é feita em `collision.gameObject`.
- `walkingJumpingAnimator.cs` declara a classe `Movimento`. O Unity exige que o
  nome do arquivo `.cs` seja igual ao da classe para o componente ser anexável
  pelo Inspector — renomeie a classe para `walkingJumpingAnimator` ou o arquivo
  para `Movimento.cs`.
- Em `walkingJumpingAnimator.cs`, o acesso a `Keyboard.current` no teste do pulo
  não é protegido por `null check`: sem teclado (ex.: teste em editor com foco
  perdido) ocorre `NullReferenceException`.
- Nos scripts com detecção de chão por colisão (`walkingJumpingPlayer`,
  `jumpingPlayer`), qualquer colisão conta como chão — inclusive paredes e o
  próprio inimigo.

## Licença

Livre para uso nos seus projetos.
