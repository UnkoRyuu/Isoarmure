﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItemBase : MonoBehaviour
{
    public Text text;

    public string InteractText;

    private bool playerTouch;

    private GameObject canvas;


    private void Start()
    {
        text.text = InteractText;
        canvas = GetComponentInChildren<Canvas>().gameObject;
        canvas.SetActive(false);
    }

    public virtual void OnInteract()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerTouch = true;
            canvas.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerTouch = false;
            canvas.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerTouch == true && Input.GetKeyDown(KeyCode.F))
        {
            OnInteract();
        }
    }
}
