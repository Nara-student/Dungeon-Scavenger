using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float Speed = 1;
    public GameObject attackBox;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
        MoveUp();
        MoveDown();
        MoveRight();
        MoveLeft();
    }

    void Idle()
    {
        rb.velocity = new Vector2(0, 0);
    }
    void MoveUp()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0, Speed);
            attackBox.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + 1);
        }
    }

    void MoveDown()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0, -Speed);
            attackBox.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + -1);
        }
    }

    void MoveLeft()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-Speed, 0);
            attackBox.transform.position = new Vector2(rb.transform.position.x + -1, rb.transform.position.y);
        }
    }

    void MoveRight()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(Speed, 0);
            attackBox.transform.position = new Vector2(rb.transform.position.x + 1, rb.transform.position.y);
        }
    }
}
