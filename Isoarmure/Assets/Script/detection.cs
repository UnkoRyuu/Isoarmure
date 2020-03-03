using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
    ennemiController ennemi;
    float tempsAttaque = 2f;
    float cooldown ;
    public StatJoueur vieDuJoueur;
    private void Start()
    {
        ennemi = GetComponent<ennemiController>();
    }
    public void OnControllerColliderHit(ControllerColliderHit collision)
    {
        //if (ennemi.lancementAnimation())
        //{
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("HitPlayer") && Time.time > cooldown)
            {
                cooldown = Time.time + tempsAttaque;
                Debug.Log("Hit");
            }
       /* }
        else
        {
            Debug.Log("PAS DE COLLISION PENDANT ANIM");
        }*/
    }
}
