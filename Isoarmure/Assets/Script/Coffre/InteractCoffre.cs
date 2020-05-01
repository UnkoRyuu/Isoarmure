using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCoffre : InteractableItemBase
{
    private bool chestIsOpen = false;
    public GameObject panel_fin_de_jeu;
    public GameObject victoire;
    public Animator anim;
    public AudioSource audioVictoire;
    

    public override void OnInteract()
    {
        chestIsOpen = !chestIsOpen;
        GetComponentInChildren<Animator>().SetBool("open", chestIsOpen);

        panel_fin_de_jeu.SetActive(true);
        victoire.SetActive(true);

        audioVictoire.Play();
        
        
    }
    
}
