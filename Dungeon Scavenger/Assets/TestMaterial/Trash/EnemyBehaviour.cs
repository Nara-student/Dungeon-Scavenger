using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    #region public Variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance; //Minimun distance for attacks
    public float moveSpeed;
    public float timer; //Cooldown between attacks
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    //private Animatior anim;                          ( Will be added later ;] )
    private float distance; //Stores distance between enemy and target
    private bool isAttackmode;
    private bool isInRange; //Checks if player is in range
    private bool isCooling; // Checks if enemy is cooling after attack
    private float intTimer;
    #endregion

    private void Awake()
    {
        intTimer = timer; //Stores initial value of timer
        // anim = GetComponent<Animator>();                ADD WITH ANIMATION!
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            hit = Physics2D.Raycast(raycast.position, Vector2.left, raycastLength, raycastMask);
            
        }
    }


    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "player")
        {
            target = trig.gameObject;
            isInRange = true;
        }
    }


}
