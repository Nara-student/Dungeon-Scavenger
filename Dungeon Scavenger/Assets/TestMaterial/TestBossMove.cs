using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBossMove : MonoBehaviour
{
    public int damageAmount = 1;
    public float cooldownDuration = 5f;
    public float attackDuration = 3f;

    private float cooldownTimer;
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

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        if (isInNormalMode)
        {
            // Rotate to face the player
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        }

        if (isInNormalMode)
        {
            // Reduce the cooldown timer over time
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                int randomAttack = Random.Range(1, 2);

                // Chooses randomly what attack to use
                if (randomAttack == 1)
                {
                    attackOne();
                    isInNormalMode = false; // Switches to attack mode
                    attackTimer = attackDuration; // Resets the attack timer
                }
                else if (randomAttack == 2)
                {
                    attackTwo();
                    isInNormalMode = false; // Switches to attack mode
                    attackTimer = attackDuration; // Resets the attack timer
                }
                else if (randomAttack == 3)
                {
                    attackThree();
                    isInNormalMode = false; // Switches to attack mode
                    attackTimer = attackDuration; // Resets the attack timer
                }

                cooldownTimer = cooldownDuration; // Reset the cooldown timer
            }
        }
        else
        {
            // Handle attack mode
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                print("Goes back to normal");
                isInNormalMode = true; // Return to normal mode
            }
        }
    }

    void attackOne()
    {
        print("ATTACK ONE IS USED!");
        // Add attack behavior here
        
    }
    void attackTwo()
    {
        print("ATTACK TWO IS USED!");
        LargeAttack.instance.largeAttackBegins();
    }

    void attackThree()
    {
        print("ATTACK THREE IS USED!");
    }
}
