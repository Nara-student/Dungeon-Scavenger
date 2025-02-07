using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static BossHealth instance;

    public int maxHealth = 10;
    public int currentHealth;

    public BossHealthBar healthbar;

    private bool isInRange;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthbar.setMaxHealth(maxHealth);
    }


    public void takeDamage(int damage)
    {
        if (isInRange)
        {
            currentHealth -= damage;
            healthbar.setHealth(currentHealth);
            if (currentHealth <= 0)
            {
                death();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }


    public void death()
    {
        TestBossMove.instance.deathEnd();
    }

    //for attacking boss BossHealth.instance.takeDamage(damage);
}
