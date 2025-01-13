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
    

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Rb.velocity = new Vector2(-Speed, Rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Rb.velocity = new Vector2(Speed, Rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            if(jumpCount < 2)
            {
              
                Rb.velocity = new Vector2(Rb.velocity.x, 5);
            }


          
        }

     

    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - (transform.up *0.75f), -Vector2.up);

        if (hit)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if(distance < 1)
            {
                jumpCount = 0;
            }
        }
        

    }

}
