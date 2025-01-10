using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float enemyHealth = 1;
    void Start()
    {
        
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
            Destroy(gameObject);
        }
    }
}
