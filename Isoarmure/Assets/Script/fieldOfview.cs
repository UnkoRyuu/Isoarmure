﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;



public class fieldOfview : MonoBehaviour
{
    private Animator anim;

    public Image danger;
    public float silent = 0f;
    public float distance;
    public float viewRadius;
    public float dureeCourseDragon; 
    bool estDetecte = false;
    ennemiController ennemiController;
    float positionX_Player = 0, positionZ_Player = 0, positionX_dragon = 0, positionZ_dragon = 0;
    GameObject player; 
    GameObject dragon;
    public NavMeshAgent agent;

    public Vector3 DirFromAngle(float anglesinDegrees)
    {
        return new Vector3(Mathf.Sin(anglesinDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(anglesinDegrees * Mathf.Deg2Rad));
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ennemiController = GetComponent<ennemiController>();
    }

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        dragon = GameObject.FindGameObjectWithTag("Dragon");

    }
    public void Update()
    {
        detection();

    }
    public void detection()
    {
        positionX_Player = player.transform.position.x;
        positionZ_Player = player.transform.position.z;
        positionX_dragon = dragon.transform.position.x;
        positionZ_dragon = dragon.transform.position.z;

        //Debug.Log(positionX_dragon + " , " + positionZ_dragon);
        //Debug.Log(positionX_Player + " , " + positionZ_Player);
        //Debug.Log(Mathf.Pow(5, 2));

        //calcule de distance entre les points
        distance = Mathf.Sqrt(Mathf.Pow(positionX_dragon - positionX_Player, 2) + Mathf.Pow(positionZ_dragon - positionZ_Player, 2));
        //Debug.Log(distance);
        if (distance <= viewRadius)
        {
            danger.gameObject.SetActive(true);
            anim.SetBool("inZone", true);
            anim.SetFloat("silent", silent);

            
            //anim.SetFloat("randomAttack", -1f);


            if (silent > 3 && ennemiController.vieCourrante > 0)
            {
                viewRadius = 3;
                //rotation vers le perso de l'IA
                faceTarget();
                //animation si déplacement de l'IA
                if (anim.GetBool("apresCri") == false)
                {
                    //Debug.Log("t'as pas crié");
                }
                else
                {
                    if (distance > 0.5)
                    {
                        anim.SetFloat("randomAttack", 0);
                        dureeCourseDragon += Time.deltaTime;
                        if (dureeCourseDragon > 3f)
                        {
                            anim.SetBool("run", false);
                            anim.SetBool("vol", true);
                            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fly Fireball Shoot"))
                            {

                            }

                            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fly Forward"))
                            {

                                agent.SetDestination(player.transform.position);
                            }
                            else
                            {
                                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Land"))
                                {
                                    dureeCourseDragon = 0;
                                    anim.SetBool("vol", false);

                                }
                            }
                        }
                        else
                        {
                            //deplacement de l'IA
                            anim.SetBool("vol", false);
                            agent.SetDestination(player.transform.position);
                            anim.SetBool("run", true);
                        }


                    }
                    else
                    {
                        anim.SetFloat("randomAttack", Random.Range(0.00001f, 3));
                        dureeCourseDragon = 0f;
                        anim.SetBool("run", false);
                    }
                }
                

                
                setPlayerDetecte(true);
            }
            else
            {
                setPlayerDetecte(false);
            }
           
        }
        else
        {
            danger.gameObject.SetActive(false);
            anim.SetBool("inZone", false);
            anim.SetFloat("randomAttack", Random.Range(0.00001f, 2));
            //anim.SetFloat("randomAttack", -1f);
        }
    }

    public void setPlayerDetecte(bool pEstDetecte)
    {
        estDetecte = pEstDetecte;
    }

    public bool getPlayerDetecte()
    {
        return estDetecte;
    }

    private void faceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }
}
