using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float enemyHealth = 1;
    Animator animator;
    public bool isDead = false;

    public string deathAnimation;
    public float deathTime;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            isDead = true;
            animator.Play(deathAnimation);
            Destroy(gameObject, deathTime);
        }
    }
}
