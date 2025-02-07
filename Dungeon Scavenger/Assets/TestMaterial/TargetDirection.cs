using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetDirection : MonoBehaviour
{
    public static TargetDirection instance;

    public GameObject target;

    private Rigidbody2D rb;
    private bool isRotationOn;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotationOn)
        {
            Vector3 direction = target.transform.position - transform.position;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        }
        else
        {
            print("STOP");
        }

    }

    public void rotationOn()
    {
        isRotationOn = true;
    }

    public void rotationOff()
    {
        isRotationOn = false;
    }

}
