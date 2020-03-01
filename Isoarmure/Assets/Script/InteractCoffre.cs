using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCoffre : InteractableItemBase
{

    private bool chestIsOpen = false;

    public override void OnInteract()
    {
        InteractText = "Press F to";

        chestIsOpen = !chestIsOpen;
        InteractText += chestIsOpen ? "close" : "open";
        
        GetComponent<Animator>().SetBool("open", chestIsOpen);
    }

}
