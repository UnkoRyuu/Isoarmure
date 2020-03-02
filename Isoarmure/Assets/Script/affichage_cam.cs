using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class affichage_cam : MonoBehaviour
{
    public Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
