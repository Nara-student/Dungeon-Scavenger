using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAttackMelee : MonoBehaviour
{
    //An extra Collider will be needed for this (See in AlmaTestScene)
    //Has problems with animations (For later)

    public GameObject target;
    public float cooldownDuration = 2f;
    public int damageAmount = 1;

    private bool isInTriggerDistance;
    private float cooldownTimer = 0f;
    private Collider2D triggerCollider; //Collider to trigger attacker;

    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTriggerDistance)
        {
            // Reduce the cooldown timer over time
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (cooldownTimer <= 0)
            {
                damageTarget();
                EnemyMovementCombat.instance.attackAnimation();
                cooldownTimer = cooldownDuration; //s Reset the cooldown timer
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTriggerDistance = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTriggerDistance = false;
    }

    void damageTarget()
    {
        print("PlayerTookDamage!");
        PlayerHealth.instance.PlayerTakesDamage(damageAmount);
    }
}
