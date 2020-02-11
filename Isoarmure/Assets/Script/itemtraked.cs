using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemtraked : MonoBehaviour
{
    public void onTrackingFound() {
        Debug.Log("found");
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void onTrackingLost()
    {
        Debug.Log("lost");
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
