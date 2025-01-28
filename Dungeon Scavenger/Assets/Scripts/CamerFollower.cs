using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollower : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyCounter;
    bool canPanToDoor = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCounter.transform.childCount == 0 && canPanToDoor == true)
        {
            transform.position = new Vector3(0, 5, -10);
            Invoke("CameraToDoor", 2);
        }


        else if (player.transform.position.y > -5 && player.transform.position.y < 5)
        {

            Vector3 cameraPosition = player.transform.position + new Vector3(0, 0, -10);
            cameraPosition.x = 0;

            transform.position = cameraPosition;
        }

       
    }

    void CameraToDoor()
    {
        canPanToDoor = false;
    }
}
