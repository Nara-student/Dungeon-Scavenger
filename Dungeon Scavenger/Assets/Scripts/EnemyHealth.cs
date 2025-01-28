using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float enemyHealth = 1;
    Animator animator;
    public bool isDead = false;
    public GameObject deathDrop;
    public bool canRevive = false;

    public string deathAnimation;
    public float deathTime;

    BoxCollider2D boxCollider;
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
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
            boxCollider.enabled = false;

            if(canRevive == false)
            {
                Invoke("AfterDeath", deathTime);
            }
            else
            {
                Invoke("Revive", deathTime);
            }
            Destroy(gameObject, deathTime);
        }
    }

    void AfterDeath()
    {
        GameObject deathDropClone = Instantiate(deathDrop, transform.position, Quaternion.identity);
    }

    void Revive()
    {
        GameObject deathDropClone = Instantiate(deathDrop, transform.position, Quaternion.identity, transform.parent.transform);
    }
}
