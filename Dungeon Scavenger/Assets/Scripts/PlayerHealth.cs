using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int maxHealth = 5;
    public int health;
    PlayerCombat playerCombat;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
        playerCombat = FindAnyObjectByType<PlayerCombat>();
    }

    public void PlayerTakesDamage(int damageAmount)
    {
        if(playerCombat.isBlocking == false)
        {
            health -= damageAmount;
            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(4);
    }
}
