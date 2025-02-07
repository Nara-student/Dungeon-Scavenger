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
    public float speedWhileBlocking = 0.5f;
    Animator anim;
    AudioSource walkSound;


    PlayerCombat playerCombat;

    public string playerDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCombat = FindAnyObjectByType<PlayerCombat>();
        anim = GetComponent<Animator>();

        if(anim == null)
        {
            return;
        }

        walkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Idle
        rb.velocity = new Vector2(0, 0);

        Movement();


    }

    void Movement()
    {
        //MoveUp
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (playerCombat.isBlocking == true)
            {
                rb.velocity = new Vector2(0, speedWhileBlocking);
            }
            else if (playerCombat.isBlocking == false && playerCombat.isAttacking == false)
            {
                rb.velocity = new Vector2(0, Speed);
                attackBox.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + 1);
                anim.Play("PlayerWalkBackwards");
            }

            if(playerCombat.holdingBlock == false)
            {
                playerDirection = "Up";
            }

            walkSound.mute = false;
        }
        //MoveDown
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (playerCombat.isBlocking == true)
            {
                rb.velocity = new Vector2(0, -speedWhileBlocking);
            }
            else if (playerCombat.isBlocking == false && playerCombat.isAttacking == false)
            {
                rb.velocity = new Vector2(0, -Speed);
                attackBox.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + -1);
                anim.Play("PlayerWalkForward");
            }
            if (playerCombat.holdingBlock == false)
            {
                playerDirection = "Down";
            }
            walkSound.mute = false;
        }
        //MoveLeft
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (playerCombat.isBlocking == true)
            {
                rb.velocity = new Vector2(-speedWhileBlocking, 0);
            }
            else if (playerCombat.isBlocking == false && playerCombat.isAttacking == false)
            {
                rb.velocity = new Vector2(-Speed, 0);
                attackBox.transform.position = new Vector2(rb.transform.position.x + -1, rb.transform.position.y);
                anim.Play("PlayerWalkLeft");
            }
            if (playerCombat.holdingBlock == false)
            {
                playerDirection = "Left";
            }
            walkSound.mute = false;
        }
        //MoveRight
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (playerCombat.isBlocking == true)
            {
                rb.velocity = new Vector2(speedWhileBlocking, 0);
            }
            else if (playerCombat.isBlocking == false && playerCombat.isAttacking == false)
            {
                rb.velocity = new Vector2(Speed, 0);
                attackBox.transform.position = new Vector2(rb.transform.position.x + 1, rb.transform.position.y);
                anim.Play("PlayerWalkRight");
            }
            if (playerCombat.holdingBlock == false)
            {
                playerDirection = "Right";
            }
            walkSound.mute = false;
        }
        else
        {
            if (playerCombat.isAttacking == false && playerCombat.holdingBlock == false)
            {
                anim.Play("PlayerIdle");
            }
            walkSound.mute = true;
        }
    }
}
