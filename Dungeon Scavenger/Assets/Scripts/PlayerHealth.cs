using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int maxHealth = 5;
    int health;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }

    public void PlayerTakesDamage(int damageAmount)
    {

        health -= damageAmount;
        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
       // SceneManager.LoadScene("GameOver");
    }
}
