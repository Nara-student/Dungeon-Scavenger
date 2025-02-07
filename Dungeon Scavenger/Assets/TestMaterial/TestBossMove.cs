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
    public float meleeCooldownDuration = 1f;
    public float attackDuration = 6f;
    public float distance = 3f;
    public float speed = 0.3f;

    private float meleeTimer;
    private float cooldownTimer;
    private float attackTimer;
    private bool isInNormalMode;
    private bool isBossAlive;
    private float distanceStop;
    private Animator anim;
    
    //Melee Attack
    private bool isInRange;
    private bool isNotInAttack;
    private bool isDoneAttack;

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
        anim = GetComponent<Animator>();

        cooldownTimer = cooldownDuration;
        attackTimer = attackDuration;
        meleeTimer = meleeCooldownDuration;


        isInNormalMode = true;
        isBossAlive = true;
        isDoneAttack = true;
    }

    void Update()
    {
        if (isBossAlive)
        {
            Vector3 direction = player.transform.position - transform.position;

            if (isInNormalMode)
            {

                // follows the player slowly!
                TargetDirection.instance.rotationOn();
                follow();
            }

            if (isInNormalMode)
            {
                // Reduce the cooldown timer over time
                cooldownTimer -= Time.deltaTime;
                isNotInAttack = true;

                if (cooldownTimer <= 0)
                {
                    int randomAttack = Random.Range(3, 3);
                    isNotInAttack = false;

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

                    cooldownTimer = cooldownDuration; // Reset the cooldown timer
                }
            }
            else
            {
                print("turning off rotation");
                TargetDirection.instance.rotationOff();

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

            if (isInRange && isNotInAttack)
            {
                print("Start attack?");
                if (meleeTimer > 0)
                {
                    meleeTimer -= Time.deltaTime;
                    anim.Play("BossIdle");
                }
                if (meleeTimer <= 1)
                {
                    attackMelee();
                    isDoneAttack = false;
                    if(meleeTimer <= 0)
                    {
                       meleeTimer = meleeCooldownDuration; // Resets the cooldown timer for melee
                        isDoneAttack = true;
                    }
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
        //BossAnimations.instance.RunAnim();
        print("walk");

        if (distanceStop >= distance)
        {
            //Makes the Enemy follow target (Player)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            anim.Play("BossRun");
            meleeTimer = meleeCooldownDuration;
            isInRange = false;
        }
        else if( distanceStop < distance)
        {
            //When in distance with target
            isInRange = true;
        }



    }

    void attackOne()
    {
        print("ATTACK ONE IS USED!");
        anim.Play("BossSlam");
        VisibleAttackRange.instance.largeAttackBegins();
    }
    void attackTwo()
    {
        //Finished
        print("ATTACK TWO IS USED!");
       
        BossShockWaves.instance.startShockWaves();
    }
    void attackMelee()
    {
        anim.Play("BossSwing");

        if (isDoneAttack)
        {
            PlayerHealth.instance.PlayerTakesDamage(damageAmount);
            print("AttacK!");
        }
    }

    public void deathEnd()
    {
        isBossAlive = false;
        anim.Play("BossDeath");
        //Destroy(gameObject);
    }





}
