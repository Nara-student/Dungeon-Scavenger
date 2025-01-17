using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int maxHealth = 5;
    public static int health;
    PlayerCombat playerCombat;

    //bool isInplace = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        health = maxHealth;
        playerCombat = FindAnyObjectByType<PlayerCombat>();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 9)
        {
            Destroy(gameObject);
        }

        //if(SceneManager.GetActiveScene().buildIndex != 3 && isInplace == false)
        //{
            //transform.position = new Vector2(0, -4.5f);
            //isInplace = true;
        //}
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

    public void PlayerTakeHeal()
    {
        if(health < maxHealth)
        {
            health += 1;
        }
    }
}
