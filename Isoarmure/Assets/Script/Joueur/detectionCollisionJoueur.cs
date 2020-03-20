using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionCollisionJoueur : MonoBehaviour
{
    public ennemiController ennemi;
    PlayerCC joueur;
    float tempsAttaque = 2f;
    float cooldown ;
    
    StatJoueur vieDuJoueur;
    private void Awake()
    {
        vieDuJoueur = GetComponent<StatJoueur>();
        joueur = GetComponent<PlayerCC>();
    }

    private void Start()
    {
        
    }
    public void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (ennemi.getAnimationLance())
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("HitPlayer") && Time.time > cooldown)
            {
                if (!joueur.getAnimationDefense())
                {

                    cooldown = Time.time + tempsAttaque;
                    vieDuJoueur.EnvoyerDegat(1);
                    Debug.Log("Hit Tail");
                }
                else
                {
                    Debug.Log("Parer ! ");
                }
            }
        }
        else
        {
            
            //Debug.Log("PAS DE COLLISION PENDANT ANIM");
        }
    }

    
}
