﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieDuJoueur : MonoBehaviour
{
    public int vie;
    public Animator anim;
    public GameObject panel_fin_du_jeu;
    public GameObject defaite;
    public AudioSource sonAnimation;
    //VieDuJoueur vieDuJoueur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mort();
    }

    public void recevoirDesDegats(int degat)
    {
        vie = vie - degat;
        Debug.Log("vie : " + vie);
    }

   public void mort()
    {
        if(vie == 0)
        {            
            anim.SetBool("die",true);
            panel_fin_du_jeu.SetActive(true);
            defaite.SetActive(true);

            sonAnimation.PlayOneShot();
            
        }
    }
}
