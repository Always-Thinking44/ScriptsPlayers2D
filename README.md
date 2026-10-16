# ScriptsPlayer2D

Repositório com scripts de controle de **players 2D** para Unity.

## Requisitos

- Unity 6 ou superior (usa `Rigidbody2D.linearVelocity`)
- Pacote **Input System** instalado (`com.unity.inputsystem`)
  - `Edit > Project Settings > Player > Active Input Handling > Input System (New)`

## Scripts

### `moviementoplayer.cs`

Movimento básico de personagem 2D: andar e pular.

| Propriedade | Descrição |
| --- | --- |
| `velocidade` | Velocidade de deslocamento horizontal (padrão: 5) |
| `forcaPulo` | Força do pulo (padrão: 7) |

**Controles:**

| Ação | Teclas |
| --- | --- |
| Andar | `A` / `D` ou `←` / `→` |
| Pular | `Espaço`, `W` ou `↑` |

**Como usar:**

1. Crie um GameObject 2D com `SpriteRenderer`, `Rigidbody2D` e um `Collider2D`.
2. Adicione o script `moviementoplayer` ao objeto.
3. Garanta que exista um chão com collider para o detectar o contato
   (o pulo só funciona quando `noChao` é verdadeiro).
4. Adicione um `Animator` com os estados/triggers `Dead` e `salto`
   (usados pelo `enemy.cs` ao tocar o inimigo).

### `enemy.cs`

Mata o player ao encostar no inimigo: toca a animação `Dead`, para o movimento
e recarrega a cena `SampleScene` após 1 segundo.

**Como usar:**

1. Crie um GameObject 2D com um `Collider2D` (e `Rigidbody2D` se necessário).
2. Adicione o script `enemy` ao objeto.
3. Garanta que o player esteja marcado com a tag `Player`.
4. Coloque a cena `SampleScene` em `File > Build Settings` para o reload funcionar.

> Limitação atual: o inimigo mata o player em qualquer direção do contato
> (não distingue pisar em cima de encostar de lado).

## Estrutura

```
ScriptsPlayer2D/
├── moviementoplayer.cs
└── enemy.cs
```

## Licença

Livre para uso nos seus projetos.
