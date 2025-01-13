using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject target;
    public float distance;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keeps from interlapping with target (Player)
        distance = Vector2.Distance(transform.position , target.transform.position);

        //Makes the Enemy follow target (Player)
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
