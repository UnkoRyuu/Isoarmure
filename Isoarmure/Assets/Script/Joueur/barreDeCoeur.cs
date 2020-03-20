using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barreDeCoeur : MonoBehaviour
{
    public Image[] listeDesCoeurs;
    VieDuJoueur vieDuJoueur;
    int coeur;
    // Start is called before the first frame update
    void Start()
    {
        vieDuJoueur = GameObject.FindGameObjectWithTag("Player").GetComponent<VieDuJoueur>();

    }

    // Update is called once per frame
    void Update()
    {
        coeur = vieDuJoueur.vie;

        switch (coeur)
        {
            case 5:
                foreach(Image img in listeDesCoeurs)
                {
                    img.gameObject.SetActive(true);
                }
            break;

            case 4:
                listeDesCoeurs[0].gameObject.SetActive(true);
                listeDesCoeurs[1].gameObject.SetActive(true);
                listeDesCoeurs[2].gameObject.SetActive(true);
                listeDesCoeurs[3].gameObject.SetActive(true);
                listeDesCoeurs[4].gameObject.SetActive(false);
                break;

            case 3:
                listeDesCoeurs[0].gameObject.SetActive(true);
                listeDesCoeurs[1].gameObject.SetActive(true);
                listeDesCoeurs[2].gameObject.SetActive(true);
                listeDesCoeurs[3].gameObject.SetActive(false);
                listeDesCoeurs[4].gameObject.SetActive(false);
                break;

            case 2:
                listeDesCoeurs[0].gameObject.SetActive(true);
                listeDesCoeurs[1].gameObject.SetActive(true);
                listeDesCoeurs[2].gameObject.SetActive(false);
                listeDesCoeurs[3].gameObject.SetActive(false);
                listeDesCoeurs[4].gameObject.SetActive(false);
                break;

            case 1:
                listeDesCoeurs[0].gameObject.SetActive(true);
                listeDesCoeurs[1].gameObject.SetActive(false);
                listeDesCoeurs[2].gameObject.SetActive(false);
                listeDesCoeurs[3].gameObject.SetActive(false);
                listeDesCoeurs[4].gameObject.SetActive(false);
                break;

            case 0:
                foreach(Image img in listeDesCoeurs)
                {
                    img.gameObject.SetActive(false);
                    Debug.Log("you died !");
             
                }
            break;

        }
    }
}
