using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    //att man best�ma hur m�nga enemies man vill ha
    public int maximumAmount;
    
    public GameObject Enemy;
    void Start()
    {
        //kamerans l�ngd och bredd
        float screenHight = Camera.main.orthographicSize;
        float screenWidht = Camera.main.orthographicSize * Camera.main.aspect;

        //hur m�nga g�nger coden ska loopas/k�ras
        for (int i = 0; i < maximumAmount; i++)
        {   
            //hela dena delen �rs� att en enemey spawnar och skickas till en random location inom kameran.
            float randomX = Random.Range(-screenWidht + 1, screenWidht -1);
            float randomY = Random.Range(-screenHight + 1,screenHight - 1); 
            GameObject Enemyclone = Instantiate(Enemy, new Vector2(randomX,randomY), Quaternion.identity, gameObject.transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
