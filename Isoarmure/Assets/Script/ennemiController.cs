using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ennemiController : MonoBehaviour
{
    public float lookRadius = 10f;
    public BarreDeVieDragon vie_Dragon;
    public int vieMax = 100;
    public int vieCourrante;
    bool animationLance = false;
    
    // Start is called before the first frame update
    void Start()
    {
        vieCourrante = vieMax;
        vie_Dragon.setVieMax(vieMax);
    }
    
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            RecevoirDegat(20);
        }*/
        
    }
    public bool getAnimationLance()
    {
        return animationLance;
    }
    public void setAnimationLance(bool valueAnim)
    {
        animationLance = valueAnim;
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
    
    public void isTailAttacking(int value)
    {
        if (value == 1)
        {
            setAnimationLance(true);
            //Debug.Log("testPositif");
           
        }
        else
        {
            setAnimationLance(false);
            //Debug.Log("testnegatif");
            
        }
        
    }
}
