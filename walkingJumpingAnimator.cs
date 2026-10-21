using UnityEngine;
using UnityEngine.InputSystem;

public class Movimento : MonoBehaviour
{

    private float horizontalInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private int velocidade = 5;
    [SerializeField] private Transform peDoPersonagem;
    [SerializeField] private LayerMask layerChao;

    private bool estaNoChao;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    
    private void Update()
    {
       
        if (Keyboard.current != null)
        {
            horizontalInput = 0f;
          
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) horizontalInput -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) horizontalInput += 1f;
        }

        if ((Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame) && estaNoChao)
            {
                rb.AddForce(Vector2.up * 600f);
            }
        
        estaNoChao = Physics2D.OverlapCircle(peDoPersonagem.position, 0.2f, layerChao);
    
        
        if(horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        animator.SetBool("movendo", horizontalInput != 0);
        animator.SetBool("salto", !estaNoChao);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * velocidade, rb.linearVelocity.y);
    }
}

