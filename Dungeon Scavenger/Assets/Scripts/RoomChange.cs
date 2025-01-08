using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    // Start is called before the first frame update
    public int scene = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene(0);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(scene);

        }
    }
}
