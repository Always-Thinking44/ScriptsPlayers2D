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

## Estrutura

```
ScriptsPlayer2D/
└── moviementoplayer.cs
```

## Licença

Livre para uso nos seus projetos.
