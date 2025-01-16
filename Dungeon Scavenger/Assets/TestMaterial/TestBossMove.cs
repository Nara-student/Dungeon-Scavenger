using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TestBossMove : MonoBehaviour
{
    public static TestBossMove instance;

    public int damageAmount = 1;
    public float cooldownDuration = 5f;
    public float attackDuration = 6f;
    public float distance = 2f;
    public float speed = 0.3f;

    private float cooldownTimer;
    private float attackTimer;
    private bool isInNormalMode;
    private bool isBossAlive;
    private float distanceStop;

    private Rigidbody2D rb;
    private GameObject player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        cooldownTimer = cooldownDuration;
        attackTimer = attackDuration;

        isInNormalMode = true;
        isBossAlive = true;
    }

    void Update()
    {
        if (isBossAlive)
        {
            Vector3 direction = player.transform.position - transform.position;

            if (isInNormalMode)
            {
                // Rotate to face the player
                float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, rot + 90);

                // follows the player slowly!
                follow();
            }

            if (isInNormalMode)
            {
                // Reduce the cooldown timer over time
                cooldownTimer -= Time.deltaTime;

                if (cooldownTimer <= 0)
                {
                    int randomAttack = Random.Range(1, 3);

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
                    AttackLarge.instance.largeAttackEnds();
                    BossShockWaves.instance.shockWavesEnds();
                    isInNormalMode = true; // Return to normal mode
                }
            }
        }
        else
        {
            print("BOSS DEAD");
        }
    }

    void follow()
    {
        //Keeps from interlapping with target (Player)
        distanceStop = Vector2.Distance(transform.position, player.transform.position);
        // anim.Play("Idle Animation");

        if (distanceStop >= distance)
        {
            //Makes the Enemy follow target (Player)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            // anim.Play("Run Animation");
        }
    }

    void attackOne()
    {
        print("ATTACK ONE IS USED!");
        VisibleAttackRange.instance.largeAttackBegins();
    }
    void attackTwo()
    {
        //Finished
        print("ATTACK TWO IS USED!");
        BossShockWaves.instance.startShockWaves();
    }

    void attackThree()
    {
        print("ATTACK THREE IS USED!");
    }


    public void deathEnd()
    {
        isBossAlive = false;
    }
}
