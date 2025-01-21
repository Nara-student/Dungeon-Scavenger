using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossAnimations : MonoBehaviour
{
    public static BossAnimations instance;
    private Animator anim;
    private bool isRunning;
    private bool isIdle;
    private bool isSwinging;
    private bool isSlamming;

    private void Awake()
    {
       instance = this;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isRunning)
        {
            anim.Play("BossRunForward");
        }

        if (isIdle)
        {
            anim.Play("BossIdle");
        }

        if (isSwinging)
        {
            anim.Play("BossSwing");
        }
        if (isSlamming)
        {
            anim.Play("BossSlam");
        }
    }

    public void IdleAnim()
    {
        isIdle = true;
    }

    public void RunAnim()
    {
        isRunning = true;
    }

    public void SwingAnim()
    {
        isSwinging = true;
    }

    public void SlamAnim()
    {
        isSlamming = true;
    }

}
