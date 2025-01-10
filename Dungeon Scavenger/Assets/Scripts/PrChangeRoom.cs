using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrChangeRoom : MonoBehaviour
{
    // Start is called before the first frame update

    public int stagedRoom;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //om playern nuddar dören går den till nästa rum
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(stagedRoom);

        }

    }
}
