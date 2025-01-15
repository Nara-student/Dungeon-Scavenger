using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healOrb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            GameObject healClone = Instantiate(healOrb, transform.position = new Vector2(0, 0), Quaternion.identity);
        }
    }
}
