using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
    Animation anim;
    protected GameObject player;
    public StatJoueur vieDuJoueur;
    private void Start()
    {
        
    }
    public void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("HitPlayer"))
        {
            Debug.Log("Hit");
        }
    }
}
