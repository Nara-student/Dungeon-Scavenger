using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrCameraFollowing : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = player.transform.position + new Vector3(0, 0, -10);

        transform.position = cameraPosition;
    }
}
