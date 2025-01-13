using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEnemyMovement : MonoBehaviour
{
    public static OldEnemyMovement instance;
    public GameObject target;
    public float speed = 1.5f;
    public float distance = 1.5f;

    private float distanceStop;
    private bool isInTriggerDistance;
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
        isInTriggerDistance = true;
    }

    void follow()
    {
        //Keeps from interlapping with target (Player)
        distanceStop = Vector2.Distance(transform.position, target.transform.position);
        // anim.Play("Idle Animation");

        if (distanceStop >= distance)
        {
            //Makes the Enemy follow target (Player)
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            // anim.Play("Run Animation");
        }
    }

    public void attackAnimation()
    {
        // anim.Play("Attack Animation"); //Might need work for while damage
    }
}
