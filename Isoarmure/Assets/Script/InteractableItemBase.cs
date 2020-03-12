using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItemBase : MonoBehaviour
{
    public Text text;

    public string InteractText;

    private bool playerTouch;

    private GameObject canvas;

    public GameObject boutonOuv;

    public GameObject boutonSaut;

    bool ouvertureCoffre = false;


    private void Start()
    {
        text.text = InteractText;
        canvas = GetComponentInChildren<Canvas>().gameObject;
        canvas.SetActive(false);
    }

    public virtual void OnInteract()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerTouch = true;
            canvas.SetActive(true);
            boutonOuv.SetActive(true);
            boutonSaut.SetActive(false);
        } 
           
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerTouch = false;
            canvas.SetActive(false);
            boutonSaut.SetActive(true);
            boutonOuv.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerTouch == true && Input.GetKeyDown(KeyCode.F))
        {
            OnInteract();
        } else if (playerTouch == true && ouvertureCoffre == true)
        {
            OnInteract();
        }


    }

    public void pressBoutonCoffre()
    {
        ouvertureCoffre = true;
    }

}