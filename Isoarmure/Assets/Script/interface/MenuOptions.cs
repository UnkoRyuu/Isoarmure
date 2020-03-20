using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOptions : MonoBehaviour
{

    public AudioMixer audioMixer;

    public GameObject panel_Option;
    
    /**public void ouvrirPanel()
    {
        if (panel_Option != null)
        {
            bool isActive = panel_Option.activeSelf;
            panel_Option.setActive(!isActive);
        }
    }**/

    public void setVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
