using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    bool isEnemyNearby = false;

    public float parryTime = 0.5f;
    float time;

    public float damage = 1;
    List <EnemyHealth> EHealth = new List<EnemyHealth>();
    void Start()
    {
        time = parryTime;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();


        //parry
        if (Input.GetKey(KeyCode.LeftShift))
        {
            time -= Time.deltaTime;
            print(time);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            time = parryTime;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth eh = (collision.gameObject.GetComponent<EnemyHealth>());
        print("Entered");
        

        isEnemyNearby = true;

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
        isEnemyNearby = false;
        
        if (eh == null)
        {
            return;
        }
        EHealth.Remove(eh);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEnemyNearby == true)
        {
            for(int i = 0; i < EHealth.Count; i++)
            {
                EHealth[i].TakeDamage(damage);
            }
            print("Attacked");
        }
    }

    void Block()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Parry
            if (time > 0)
            {

            }
        }
    }
}
