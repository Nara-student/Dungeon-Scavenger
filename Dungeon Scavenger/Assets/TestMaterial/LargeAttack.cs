using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeAttack : MonoBehaviour
{
    public static LargeAttack instance;
    public GameObject visibleAttackRange;
    public Transform attackPos;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    public void largeAttackBegins()
    {
        Instantiate(visibleAttackRange, attackPos.position, Quaternion.identity);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
