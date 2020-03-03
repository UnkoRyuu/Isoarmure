using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ennemiController : MonoBehaviour
{
    public float lookRadius = 10f;
    public BarreDeVieDragon vie_Dragon;
    public int vieMax = 100;
    public int vieCourrante;
    private bool estLance;
    Animation animCoupDeQueue;
    
    // Start is called before the first frame update
    void Start()
    {
        vieCourrante = vieMax;
        vie_Dragon.setVieMax(vieMax);
        animCoupDeQueue = GetComponent<Animation>();
        estLance = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RecevoirDegat(20);
        }
        
    }
    public void RecevoirDegat(int degat)
    {
        vieCourrante -= degat;
        vie_Dragon.SetVie(vieCourrante);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void setEstLance(bool NewEstLance)
    {
        estLance = NewEstLance;
    }
    public bool lancementAnimation() {
        if (animCoupDeQueue.IsPlaying("Tail Attack")){
            
            Debug.Log("testPositif");
        }
        else
        {
            Debug.Log("testnegatif");
            setEstLance(false);
        }

        return estLance;
    }
}
