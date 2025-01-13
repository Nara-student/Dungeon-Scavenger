using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isBlocking = false;
    bool canAttack = true;
    public bool isParrying = false;

    public float parryTime = 0.1f;
    float time;

    public float cooldown = 0.5f;
    float attackCooldown;

    public float damage = 1;
    List <EnemyHealth> EHealth = new List<EnemyHealth>();
    void Start()
    {
        time = parryTime;
        attackCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        Attack();
        Block();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth eh = (collision.gameObject.GetComponent<EnemyHealth>());
        print("Entered");
        


        //Ifall scriptet finns inte
        if(eh == null)
        {
            return;
        }
        EHealth.Add(eh);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyHealth eh = (collision.gameObject.GetComponent<EnemyHealth>());
        print("exit");
        
        if (eh == null)
        {
            return;
        }
        EHealth.Remove(eh);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) && attackCooldown <= 0 && canAttack == true)
        {
            for(int i = 0; i < EHealth.Count; i++)
            {
                EHealth[i].TakeDamage(damage);
            }
            print("Attacked");
            attackCooldown = cooldown;
        }
    }

    void Block()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isBlocking = true;
            canAttack = false;
            time -= Time.deltaTime;
            //Parry
            if (time > 0)
            {
                isParrying = true;
            }
            if(time < 0)
            {
                isParrying = false;
            }
        }

        //Block exit
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            time = parryTime;
            isBlocking = false;
            canAttack = true;
            isParrying = false;
        }
    }
}
