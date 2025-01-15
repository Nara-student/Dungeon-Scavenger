using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee2 : MonoBehaviour
{
    //An extra Collider will be needed for this (See in AlmaTestScene)
    //Has problems with animations (For later)

    public GameObject target;
    public float cooldownDuration = 2f;
    public int damageAmount = 1;
    public bool isStunned = false;
    public bool hasAttacked = false;

    private bool isInTriggerDistance;
    private float cooldownTimer = 0f;
    private Collider2D triggerCollider; //Collider to trigger attacker;

    float stunDuration = 5;
    float stunTimer;

    PlayerCombat playerCombat;
    EnemyMovementCombat enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<Collider2D>();
        playerCombat = FindAnyObjectByType<PlayerCombat>();
        target = GameObject.Find("Player");
        enemyMovement = transform.parent.GetComponent<EnemyMovementCombat>();
        
        //stunTimer
        stunTimer = stunDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce stun timer over time
        stunTimer -= Time.deltaTime;

        // Reduce the cooldown timer over time
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            hasAttacked = true;
        }
        else if(cooldownTimer < 0)
        {
            hasAttacked = false;
        }

        //stunned
        if (stunTimer < 0)
        {
            isStunned = false;
            stunTimer = stunDuration;
        }
       

        if (isInTriggerDistance)
        {
            //stun
            if (playerCombat.isParrying == true)
            {
                isStunned = true;
                print(isStunned);
            }

            //attack
            if (cooldownTimer <= 0 && playerCombat.isBlocking == false && isStunned == false)
            {
                enemyMovement.attackAnimation();
                cooldownTimer = cooldownDuration; //s Reset the cooldown timer

                Invoke("damageTarget", 0.3f);
                print("damage");
            }else if(cooldownTimer <= 0 && playerCombat.isBlocking == true)
            {
                enemyMovement.attackAnimation();
                cooldownTimer = cooldownDuration;
                print("blocked");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            isInTriggerDistance = true;
            hasAttacked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTriggerDistance = false;
    }

 

    void damageTarget()
    {
        if(playerCombat.isBlocking == false && isStunned == false && isInTriggerDistance == true)
        {
            print("PlayerTookDamage!");
            PlayerHealth.instance.PlayerTakesDamage(damageAmount);
        }
    }
}
