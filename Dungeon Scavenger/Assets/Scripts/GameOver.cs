using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //n�r man trycker soace kommer man tillbaka till main menu
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
