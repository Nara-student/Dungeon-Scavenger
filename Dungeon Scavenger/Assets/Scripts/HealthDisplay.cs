using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI healthShow;
    int health;
    PlayerHealth playerHealth;

    void Start()
    {
        healthShow = GetComponent<TextMeshProUGUI>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        health = playerHealth.health;
        healthShow.text = ("Health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        healthShow.text = ("Health: " + health);
    }
}
