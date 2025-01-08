using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Enemy;
    void Start()
    {
        float random = Random.Range(-4, 3);
        GameObject Enemyclone = Instantiate(Enemy, transform.position = new Vector2(15, random) ,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
