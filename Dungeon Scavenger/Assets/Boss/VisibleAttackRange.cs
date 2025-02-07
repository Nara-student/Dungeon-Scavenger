using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleAttackRange : MonoBehaviour
{
    public static VisibleAttackRange instance;
    public float visibilityDuration = 2f;

    private SpriteRenderer visibleattackRange;
    private float visibilityTime;
    private bool attackIsGoing;
    private Animator anim;
   

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        visibleattackRange = GetComponent<SpriteRenderer>();
        anim = GetComponentInParent<Animator>();
        visibleattackRange.enabled = false;
    }
    void Update()
    {
        if(attackIsGoing == true)
        {
            visibleattackRange.enabled = true;
            if (visibilityTime > 0)
            {
                anim.Play("BeforeSlam");
                visibilityTime -= Time.deltaTime;
            }
            if (visibilityTime <= 0)
            {
                anim.Play("BossSlam");
                AttackLarge.instance.getReadyForAttack();
                attackIsGoing = false;
            }

        }
        else if(attackIsGoing == false)
        {
            visibleattackRange.enabled = false;
        }
    }


    public void largeAttackBegins()
    {
        visibilityTime = visibilityDuration;
        attackIsGoing = true;
    }

}
