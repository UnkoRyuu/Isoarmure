using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatJoueur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnvoyerDegat(int degat)
    {
        VieDuJoueur vie = GameObject.FindGameObjectWithTag("Player").GetComponent<VieDuJoueur>();
        vie.recevoirDesDegats(degat);
    }
}
