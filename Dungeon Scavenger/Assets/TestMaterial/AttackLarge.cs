using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLarge : MonoBehaviour
{
    public static AttackLarge instance;
    public GameObject target;
    public int damageAmount = 5;

    private Rigidbody2D rb;
    private Collider2D damageRange;
    private bool isInAttackRange;
    private bool isAttackOn;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageRange = GetComponent<Collider2D>();
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(isAttackOn && isInAttackRange)
        {
            print("Player took damage!");
            PlayerHealth.instance.PlayerTakesDamage(damageAmount);
            isAttackOn = false;
        }
    }

    public void getReadyForAttack()
    {
        gameObject.SetActive(true);
        isAttackOn = true;
    }

    public void largeAttackEnds()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInAttackRange = true;
    }
}
