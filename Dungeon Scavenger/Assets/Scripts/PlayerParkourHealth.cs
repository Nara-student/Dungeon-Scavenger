using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParkourHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDead = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Health()
    {
        isDead = true;
        print("Dead");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(6);
    }
}
