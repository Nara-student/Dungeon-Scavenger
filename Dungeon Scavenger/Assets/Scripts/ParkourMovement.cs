using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ParkourMovement : MonoBehaviour
{
    public int Speed;

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

        if (Input.GetKey(KeyCode.Space))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 3);
        }

    }
}
