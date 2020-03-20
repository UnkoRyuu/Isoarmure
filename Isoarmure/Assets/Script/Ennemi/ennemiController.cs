using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ennemiController : MonoBehaviour
{
    public float lookRadius = 10f;
    public BarreDeVieDragon vie_Dragon;
    public Animator animDragon;
    public int vieMax = 100;
    public int vieCourrante;
    bool animationLance = false;

    Transform target;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        vieCourrante = vieMax;
        vie_Dragon.setVieMax(vieMax);
        //target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        mort();
        //float distance = Vector3(transform.position, target.position);

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

    public void mort()
    {
        Debug.Log("coucou");
      if (vieCourrante == 0)
      {
        animDragon.SetBool("die", true);

            }
        
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
