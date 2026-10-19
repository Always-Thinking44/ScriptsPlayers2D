using UnityEngine;
using UnityEngine.InputSystem;

public class walkingJumpingPlayer : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 7f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float movimento;
    private bool noChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var teclado = Keyboard.current;
        if (teclado == null) return;

        movimento = 0f;

        if (teclado.aKey.isPressed || teclado.leftArrowKey.isPressed){
            movimento = -1f;
            sprite.flipX = true;
        }

        if (teclado.dKey.isPressed || teclado.rightArrowKey.isPressed){
            movimento = 1f;
             sprite.flipX = false;
        }
           

        if (noChao)
        {
            if (teclado.spaceKey.wasPressedThisFrame || teclado.upArrowKey.isPressed || teclado.wKey.isPressed)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        noChao = true;
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        noChao = false;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);
    }
}
