using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static BossHealth instance;

    public int maxHealth = 10;
    public int currentHealth;

    public BossHealthBar healthbar;

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

        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }

    //for attacking boss BossHealth.instance.takeDamage(damage);
}
