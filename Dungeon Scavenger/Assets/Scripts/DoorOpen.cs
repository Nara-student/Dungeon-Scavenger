using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    Animator anim;
    EnemySpawner enemyCounter;
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyCounter = FindAnyObjectByType<EnemySpawner>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter.transform.childCount == 0)
        {
            isOpen = true;
            print(isOpen);
        }

        if (isOpen == true)
        {
            anim.Play("DoorOpening");
        }
    }
}
