using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ParkourMovement : MonoBehaviour
{
    public int Speed;
    int jumpCount = 0;
    Rigidbody2D Rb;
    Animator anim;
    SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Rb.velocity = new Vector2(-Speed, Rb.velocity.y);
            anim.Play("PlayerWalkRight");
            sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Rb.velocity = new Vector2(Speed, Rb.velocity.y);
            anim.Play("PlayerWalkRight");
            sprite.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();


          
        }

        if(Rb.velocity.x == 0 && Rb.velocity.y == 0)
        {
            anim.Play("PlayerIdle");
        }

    }


    void Jump()
    {
        jumpCount++;

        if (jumpCount <= 2)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;
    }

}
