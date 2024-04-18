using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float JumpikForcik;
    public Rigidbody2D ABCDEFG;

    public int points;
    public static bool GameOver;
    public static bool HasStarted;
    public GameObject gameOverScreen;

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
            ABCDEFG.AddForce(new Vector2(0, JumpikForcik), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Die!");
        GameOver = true;
        gameOverScreen.SetActive(true);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointZone"))
        {
            points++;
        }
    }

 public void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
