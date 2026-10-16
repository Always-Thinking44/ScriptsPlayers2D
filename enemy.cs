using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; 
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            collision.gameObject.GetComponent<Movimento>().enabled = false;
            collision.gameObject.GetComponent<Animator>().SetBool("salto", false);
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