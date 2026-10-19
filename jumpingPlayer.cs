using UnityEngine;
using UnityEngine.InputSystem;

public class jumpingPlayer : MonoBehaviour
{
    public float forcaPulo = 7f;

    private Rigidbody2D rb;
    private bool noChao;

    void Update()
    {
        var teclado = Keyboard.current;
        if (teclado == null) return;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
