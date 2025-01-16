using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchAttack : MonoBehaviour
{
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
    EnemyMarch enemyMarch;

    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<Collider2D>();
        playerCombat = FindAnyObjectByType<PlayerCombat>();
        target = GameObject.Find("Player");
        enemyMarch = transform.parent.GetComponent<EnemyMarch>();

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
        else if (cooldownTimer < 0)
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
                enemyMarch.attackAnimation();
                cooldownTimer = cooldownDuration; //s Reset the cooldown timer

                Invoke("damageTarget", 0.3f);
                print("damage");
            }
            else if (cooldownTimer <= 0 && playerCombat.isBlocking == true)
            {
                enemyMarch.attackAnimation();
                cooldownTimer = cooldownDuration;
                print("blocked");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
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
        if (playerCombat.isBlocking == false && isStunned == false && isInTriggerDistance == true)
        {
            print("PlayerTookDamage!");
            PlayerHealth.instance.PlayerTakesDamage(damageAmount);
        }
    }
}
