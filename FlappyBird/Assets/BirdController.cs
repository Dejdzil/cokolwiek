using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float JumpikForcik;
    public Rigidbody2D ABCDEFG;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            ABCDEFG.AddForce(new Vector2(0, JumpikForcik), ForceMode2D.Impulse);
        }
    }
}
