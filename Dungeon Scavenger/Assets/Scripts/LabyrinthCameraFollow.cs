using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthCameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    float cameraPositionY;
    float cameraPositionX;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //kamera y axel
        if (player.transform.position.y > -40 && player.transform.position.y < 115)
        {

            cameraPositionY = player.transform.position.y;

            transform.position = new Vector3(cameraPositionX, cameraPositionY, -10);
        }

        //kamera x axel
        if (player.transform.position.x > -86 && player.transform.position.x < 81)
        {

            cameraPositionX = player.transform.position.x;

            transform.position = new Vector3(cameraPositionX, cameraPositionY, -10);
        }

    }
}
