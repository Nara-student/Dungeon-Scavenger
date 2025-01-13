using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovementCombat : MonoBehaviour
{
    public static EnemyMovementCombat instance;
    public GameObject target;
    public float speed = 1.5f;
    public float distanceStop;

    private bool isInTriggerDistance;
    private bool distance;
    private Rigidbody2D rb;
    private Collider2D triggerCollider; //Collider to trigger distance;
    private Animator anim;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggerCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isInTriggerDistance)
        {
            follow();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            isInTriggerDistance = true;
        }
    }

    void follow()
    {
        //Keeps from interlapping with target (Player)
        distanceStop = Vector2.Distance(transform.position, target.transform.position);
        //anim.Play("Idle Animation");

        if (distanceStop >= 1.3)
        {
            Vector2 dir = target.transform.position - transform.position;

            //Direction decider
            if (Mathf.Abs(dir.x) - Mathf.Abs(dir.y) < 0.5f)
            {
                dir.x = 0;
            }
            else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
            {
                dir.x = 0;
            }
            else if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                dir.y = 0;
            }
            

            rb.velocity = dir.normalized * speed;

            if(rb.velocity.y == -speed)
            {
                anim.Play("GoblinForwardWalk");
            }
            if(rb.velocity.y == speed)
            {
                anim.Play("GoblinBackwardsWalk");
            }
            if(rb.velocity.x == -speed)
            {
                anim.Play("GoblinLeftWalk");
            }
            if (rb.velocity.x == speed)
            {
                anim.Play("GoblinRightWalk");
            }

            //Makes the Enemy follow target (Player)
            //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            //anim.Play("Run Animation");
        }
    }

    public void attackAnimation()
    {
        //anim.Play("Attack Animation"); //Might need work for while damage
    }
}
