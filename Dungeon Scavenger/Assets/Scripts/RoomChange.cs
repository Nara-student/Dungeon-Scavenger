using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject enemyCounter;

    public int stagedRoom;

    //public int range1;
    //public int range2;
    //int randomRoom = Random.Range(range1, range2);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        //om playern nuddar dören när alla enemies är döda kommer den skickas rill nästa rum
        if (collision.gameObject.name == "Player" && enemyCounter.transform.childCount == 0)
        {
            SceneManager.LoadScene(stagedRoom);

        }
    }
}
