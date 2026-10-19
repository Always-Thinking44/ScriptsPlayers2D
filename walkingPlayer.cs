using UnityEngine;
using UnityEngine.InputSystem;

public class walkingPlayer : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float movimento;

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
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);
    }
}
