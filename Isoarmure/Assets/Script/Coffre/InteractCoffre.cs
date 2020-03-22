using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCoffre : InteractableItemBase
{
    private bool chestIsOpen = false;
    public GameObject panel_victoire;
    public Animator anim;

    public override void OnInteract()
    {
        chestIsOpen = !chestIsOpen;
        GetComponentInChildren<Animator>().SetBool("open", chestIsOpen);

        panel_victoire.SetActive(true);
        
        
        
    }
    
}
