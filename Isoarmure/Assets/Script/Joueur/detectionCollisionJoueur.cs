using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionCollisionJoueur : MonoBehaviour
{
    public ennemiController ennemi;
    Animator anim; 
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
        anim = GetComponent<Animator>();
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
                    anim.SetBool("toucher", true);
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
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("FireBall") && Time.time > cooldown)
        {
            cooldown = Time.time + tempsAttaque-1;
            vieDuJoueur.EnvoyerDegat(1);
            anim.SetBool("toucher", true);
            Debug.Log("Hit Ball");          
        }
    }

    public void stopAnimToucher(int value)
    {
        anim.SetBool("toucher",false);
    }
    
}
