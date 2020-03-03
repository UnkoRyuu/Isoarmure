using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCoffre : InteractableItemBase
{
    private bool chestIsOpen = false;

    


    public override void OnInteract()
    {
        chestIsOpen = !chestIsOpen;
        GetComponentInChildren<Animator>().SetBool("open", chestIsOpen);
    }

}
