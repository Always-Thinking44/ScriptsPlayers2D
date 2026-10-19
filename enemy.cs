using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    private Animator animatorPlayer;
    private Rigidbody2D rbPlayer;
    private walkingJumpingPlayer movPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animatorPlayer = collision.gameObject.GetComponent<Animator>();
            rbPlayer = collision.gameObject.GetComponent<Rigidbody2D>();
            movPlayer = collision.gameObject.GetComponent<walkingJumpingPlayer>();

            animatorPlayer.SetTrigger("Dead");
            rbPlayer.linearVelocity = Vector2.zero;
            rbPlayer.bodyType = RigidbodyType2D.Kinematic;
            movPlayer.enabled = false;
            animatorPlayer.SetBool("salto", false);
            Invoke("LoadScene", 1f);
        }
    }

    void LoadScene(){
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        
    }
}