using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_principal : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("scene de jeu", LoadSceneMode.Additive);
    }
}
