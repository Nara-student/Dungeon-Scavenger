using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    private float health;
    public float startHealth;
    public Image healthBar;

    private void Awake()
    {
        instance = this;
    }

    void start()
    {
        health = 5;
    }

    public void PlayerTakesDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0f)
        {
            Death();
        }

    }

    void Death()
    {
        Destroy(gameObject);
        // SceneManager.LoadScene("(Whatever scene you want)");
    }


}
