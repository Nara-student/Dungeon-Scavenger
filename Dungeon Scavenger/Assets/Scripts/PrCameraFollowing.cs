using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrCameraFollowing : MonoBehaviour
{
    public GameObject player;

    PlayerParkourHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerParkourHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.isDead == false)
        {
            Vector3 cameraPosition = player.transform.position + new Vector3(0, 0, -10);

            transform.position = cameraPosition;
        }
    }
}
