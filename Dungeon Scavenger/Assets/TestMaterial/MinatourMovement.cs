using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinatourMovement : MonoBehaviour
{
    public int damageAmount = 1;
    public float cooldownDuration = 5f;
    public float attackDuration = 3f;

    private float cooldownTimer;
    private Animator anim;
    private float attackTimer;
    private bool isInNormalMode;


    private Rigidbody2D rb;
    private GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        cooldownTimer = cooldownDuration;
        attackTimer = attackDuration;

        isInNormalMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        if (isInNormalMode)
        {
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90); //Moves head
        }

        // Reduce the cooldown timer over time
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer <= 0)
        {
            int randomAttack = Random.Range(1, 2);

            //Chooses randomly on what attack to use!

            if (randomAttack == 1)
            {
                attackOne();
                isInNormalMode = false;

                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                if (attackTimer <= 0)
                {
                    print("Goes back to normal");
                    isInNormalMode = true;
                    cooldownTimer = cooldownDuration; //Resets the cooldown timer
                    return;
                }
            }
            else if (randomAttack == 2)
            {
                attackTwo();
            }
            else if (randomAttack == 3)
            {
                attackThree();
            }
        }
    }

    void attackOne()
    {
        print("ATTACK ONE IS USED!");

    }
    void attackTwo()
    {
        print("ATTACK TWO IS USED!");
    }
    void attackThree()
    {
        print("ATTACK THREE IS USED!");
    }
}
