using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 20f;
    public Transform FollowPos = null;
    public Animator animDragon;

    private void Update()
    {
        if (!animDragon.GetCurrentAnimatorStateInfo(0).IsName("Sleeping"))
        {
            this.transform.LookAt(FollowPos);
            animDragon.Play("walk");
        }
        
    }
}