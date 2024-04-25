using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float JumpikForcik;
    public float MaxVelocity;
    public Rigidbody2D ABCDEFG;

    public int points;
    public static bool GameOver;
    public static bool HasStarted;
    public GameObject gameOverScreen;
    public Animator animator;
    public AudioSource audioSource;

    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip HitSound;

    // Start is called before the first frame update
    void Start()
    {
        ABCDEFG.gravityScale = 0f;
        GameOver = false;
        HasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameOver)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!HasStarted) { 
                HasStarted = true;
                ABCDEFG.gravityScale = 1f;

            }

            audioSource.clip = jumpSound;
            audioSource.Play();

            animator.SetTrigger("FlapWings");
            ABCDEFG.velocity = Vector2.zero;
            ABCDEFG.AddForce(new Vector2(0, JumpikForcik), ForceMode2D.Impulse);
        }

        if (ABCDEFG.velocity.y >MaxVelocity)
        {
            ABCDEFG.velocity = new Vector2(0, MaxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Die!");
        GameOver = true;
        gameOverScreen.SetActive(true);

        audioSource.clip = HitSound;
        audioSource.Play();

        if (points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", points);    
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointZone"))
        {
            audioSource.clip = scoreSound;
            audioSource.Play();
            points++;
        }
    }

 public void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
