using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieDuJoueur : MonoBehaviour
{
    public int vie;
    public Animator anim;
    //VieDuJoueur vieDuJoueur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recevoirDesDegats(int degat)
    {
        vie = vie - degat;
        Debug.Log("vie : " + vie);
    }

    public void mort()
    {
        if(vie <= 0)
        {
            anim.Play("death");
        }
    }
}
