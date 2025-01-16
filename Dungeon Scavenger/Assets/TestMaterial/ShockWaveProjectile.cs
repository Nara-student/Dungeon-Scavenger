using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveProjectile : MonoBehaviour
{
    public float forceOfProjectile = 1.5f;
    public int damageAmount = 3;
    public float despawnTimer = 5f;

    private GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * forceOfProjectile;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 90);
    }
    void Update()
    {
        if (despawnTimer  > 0)
        {
            despawnTimer -= Time.deltaTime;
        }
        if (despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("PlayerTookDamage!");
        //PlayerHealth.instance.PlayerTakesDamage(damageAmount);
        Destroy(gameObject);
    }
}
