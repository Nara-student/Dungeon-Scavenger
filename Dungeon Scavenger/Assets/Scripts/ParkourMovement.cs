using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkourMovement : MonoBehaviour
{
    public int Speed;
    int jumpCount = 0;
    Rigidbody2D Rb;
    Animator anim;
    SpriteRenderer sprite;
    bool canFly = true;
    bool isJumping = false;

    CapsuleCollider2D capsuleCollider;

    PlayerParkourHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerParkourHealth>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && playerHealth.isDead == false)
        {
            Rb.velocity = new Vector2(-Speed, Rb.velocity.y);
            
            if(isJumping == false)
            {
                anim.Play("PlayerWalkLeft");
            }
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && playerHealth.isDead == false)
        {
            Rb.velocity = new Vector2(Speed, Rb.velocity.y);
            
            if (isJumping == false)
            {
                anim.Play("PlayerWalkLeft");
            }
            sprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerHealth.isDead == false)
        {
            Jump();


          
        }

        if(Rb.velocity.x == 0 && Rb.velocity.y == 0 && playerHealth.isDead == false)
        {
            anim.Play("PlayerIdle");
        }

        if(playerHealth.isDead == true && canFly == true)
        {
            Rb.velocity = new Vector2(0, 10);
            Rb.gravityScale = 5;
            capsuleCollider.enabled = false;
            Invoke("Death", 0.1f);
            Invoke("GameOver", 1);
        }

    }


    void Jump()
    {
        jumpCount++;

        if (jumpCount <= 2)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 5);
            anim.Play("PlayerJump");
            isJumping = true;
        }
    }

    void Death()
    {
        canFly = false;
    }

    void GameOver()
    {
        SceneManager.LoadScene(6);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;
        isJumping = false;
    }

}
