using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovementCombat : MonoBehaviour
{
    public static EnemyMovementCombat instance;
    public GameObject target;
    public float speed = 1.5f;
    public float distanceStop;

    private bool distance;
    private bool canChase = false;
    private Rigidbody2D rb;
    private Collider2D triggerCollider; //Collider to trigger distance;
    private Animator anim;

    public GameObject attackBox;
    EnemyAttackMelee2 enemyAttack;
    EnemyHealth enemyHealth;

    [SerializeField] float viewRange = 5;

    string direction;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggerCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        enemyAttack = attackBox.GetComponent<EnemyAttackMelee2>();
        enemyHealth = GetComponent<EnemyHealth>();
        target = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (canChase)
        {
            follow();
        }

        isInTriggerDistance();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }

    void isInTriggerDistance()
    {
        float direction = Vector2.Distance(transform.position, target.transform.position);

        if (direction <= viewRange)
        {
            canChase = true;
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

            //movement

            if (enemyAttack.isStunned == true && enemyHealth.isDead == false)
            {
                rb.velocity = new Vector2(0, 0);
                StunDirection();
            }
            else if(enemyAttack.hasAttacked == false && enemyHealth.isDead == false)
            {
                rb.velocity = dir.normalized * speed;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }

            MovementDirection();

            //Makes the Enemy follow target (Player)
            //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            //anim.Play("Run Animation");
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, viewRange);
    }
    public void attackAnimation()
    {
        if (direction == "Down")
        {
            //gå ner
            anim.Play("GoblinForwardAttack"); //Might need work for while damage
        }
        if (direction == "Up")
        {
            //gå upp
            anim.Play("GoblinBackwardsAttack"); //Might need work for while damage
        }
        if (direction == "Left")
        {
            //gå vänster
            anim.Play("GoblinLeftAttack"); //Might need work for while damage
        }
        if (direction == "Right")
        {
            //gå höger
            anim.Play("GoblinRightAttack"); //Might need work for while damage
        }
    }

    void MovementDirection()
    {
        if (rb.velocity.y == -speed && enemyAttack.hasAttacked == false)
        {
            //gå ner
            anim.Play("GoblinForwardWalk");
            attackBox.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + -1);
            direction = "Down";
        }
        if (rb.velocity.y == speed && enemyAttack.hasAttacked == false)
        {
            //gå upp
            anim.Play("GoblinBackwardsWalk");
            attackBox.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + 1);
            direction = "Up";
        }
        if (rb.velocity.x == -speed && enemyAttack.hasAttacked == false)
        {
            //gå vänster
            anim.Play("GoblinLeftWalk");
            attackBox.transform.position = new Vector2(rb.transform.position.x + -1, rb.transform.position.y);
            direction = "Left";
        }
        if (rb.velocity.x == speed && enemyAttack.hasAttacked == false)
        {
            //gå höger
            anim.Play("GoblinRightWalk");
            attackBox.transform.position = new Vector2(rb.transform.position.x + 1, rb.transform.position.y);
            direction = "Right";
        }
    }

    void StunDirection()
    {
        if (direction == "Down")
        {
            //gå ner
            anim.Play("GoblinStunnedForward"); //Might need work for while damage
        }
        if (direction == "Up")
        {
            //gå upp
            anim.Play("GoblinStunnedBackwards"); //Might need work for while damage
        }
        if (direction == "Left")
        {
            //gå vänster
            anim.Play("GoblinStunnedLeft"); //Might need work for while damage
        }
        if (direction == "Right")
        {
            //gå höger
            anim.Play("GoblinStunnedRight"); //Might need work for while damage
        }
    }
}
