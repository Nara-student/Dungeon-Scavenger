using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShockWaves : MonoBehaviour
{
    public static BossShockWaves instance;

    public GameObject target;
    public float cooldownDuration = 2f;
    public int damageAmount = 5;
    public GameObject projectile;
    public Transform projectilePos; //Spawn for projectile

    private bool isTheAttackStarting;
    private float cooldownTimer = 0f;
    private Collider2D meleeAttackDistance;
    private bool isIsRange;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        meleeAttackDistance = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTheAttackStarting)
        {
            // Reduces the cooldown timer over time
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (cooldownTimer <= 0)
            {
                shootProjectile();
                // EnemyMovementCombat.instance.attackAnimation();
                cooldownTimer = cooldownDuration; // Resets the cooldown timer
            }
        }
        if (isIsRange && isTheAttackStarting)
        {
            //To also use melee if too close to boss
            meleeAttack();
        }
    }

    public void startShockWaves()
    {
        isTheAttackStarting = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isIsRange = true;
    }

    void shootProjectile()
    {
        //Faces the player each swing
        Vector3 direction = target.transform.position - transform.position;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);


        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }

    void meleeAttack()
    {
        if (cooldownTimer <= 0)
        {
            damageTarget();
        }
    }

    void damageTarget()
    {
        print("PlayerTookDamage!");
        PlayerHealth.instance.PlayerTakesDamage(damageAmount);
    }

    public void shockWavesEnds()
    {
        isTheAttackStarting = false;
    }
}
