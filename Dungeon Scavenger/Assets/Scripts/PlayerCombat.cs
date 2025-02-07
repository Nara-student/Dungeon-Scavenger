using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isBlocking = false;
    bool canAttack = true;
    public bool holdingBlock = false;
    public bool isParrying = false;

    public float parryTime = 0.1f;
    float time;

    public float cooldown = 0.5f;
    float attackCooldown;
    public bool isAttacking = false;

    public int damage = 1;
    List <EnemyHealth> EHealth = new List<EnemyHealth>();
    BossHealth bossHealth;

    Animator anim;
    PlayerMovement playerMovement;

    public GameObject attackSound;
    void Start()
    {
        time = parryTime;
        attackCooldown = cooldown;
        anim = transform.parent.GetComponent<Animator>();
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        //attack bool end
        if(attackCooldown < 0)
        {
            isAttacking = false;
        }

        Attack();
        Block();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth eh = (collision.gameObject.GetComponent<EnemyHealth>());

        bossHealth = collision.gameObject.GetComponent<BossHealth>();


        //Ifall scriptet finns inte
        if(eh == null)
        {
            return;
        }
        EHealth.Add(eh);
        print("Entered");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyHealth eh = (collision.gameObject.GetComponent<EnemyHealth>());
        print("exit");

        bossHealth = null;
        
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

            if(bossHealth != null)
            {
                bossHealth.takeDamage(damage);
                print("Boss");
            }

            print("Attacked");
            attackCooldown = cooldown;
            AttackDirection();
            isAttacking = true;

            GameObject attacksoundclone =  Instantiate(attackSound);
            Destroy(attacksoundclone, 3);
        }
    }

    void Block()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isBlocking = true;
            canAttack = false;
            holdingBlock = true;

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
            BlockDirection();
        }

        //Block exit
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            time = parryTime;
            isBlocking = false;
            canAttack = true;
            isParrying = false;
            holdingBlock = false;
        }
    }

    void AttackDirection()
    {
        if (playerMovement.playerDirection == "Down")
        {
            //gå ner
            anim.Play("PlayerAttackForward"); //Might need work for while damage
        }
        if (playerMovement.playerDirection == "Up")
        {
            //gå upp
            anim.Play("PlayerAttackBackwards"); //Might need work for while damage
        }
        if (playerMovement.playerDirection == "Left")
        {
            //gå vänster
            anim.Play("PlayerAttackLeft"); //Might need work for while damage
        }
        if (playerMovement.playerDirection == "Right")
        {
            //gå höger
            anim.Play("PlayerAttackRight"); //Might need work for while damage
        }
    }

    void BlockDirection()
    {
        if (playerMovement.playerDirection == "Down" && holdingBlock == true)
        {
            //gå ner
            anim.Play("PlayerBlockForward"); //Might need work for while damage
        }
        if (playerMovement.playerDirection == "Up" && holdingBlock == true)
        {
            //gå upp
            anim.Play("PlayerBlockBackwards"); //Might need work for while damage
        }
        if (playerMovement.playerDirection == "Left" && holdingBlock == true)
        {
            //gå vänster
            anim.Play("PlayerBlockLeft"); //Might need work for while damage
        }
        if (playerMovement.playerDirection == "Right" && holdingBlock == true)
        {
            //gå höger
            anim.Play("PlayerBlockRight"); //Might need work for while damage
        }
    }
}
