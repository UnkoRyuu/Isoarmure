using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject option;
    public GameObject credit;

    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("scene du jeu");
    }

    public void menuOption()
    {
        menu.SetActive(false);
        option.SetActive(true);
    }

    public void menuCredit()
    {
        menu.SetActive(false);
        option.SetActive(false);
        credit.SetActive(true);

    }
    public void retourOption()
    {
        menu.SetActive(true);
        option.SetActive(false);
    }

    public void retourCredit()
    {
        menu.SetActive(true);
        credit.SetActive(false);
    }
}
