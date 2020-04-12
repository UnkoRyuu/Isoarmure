using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ennemiController : MonoBehaviour
{
    public GameObject boucheDuDragon;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject perso;
    public GameObject sphere;
    spherePara lancement;
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
        lancement = GameObject.Find("Sphere").GetComponent<spherePara>();
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


    public void lanceBouleDeFeu(int value)
    {
        if (value == 1)
        {
            // position du point sur la bouche du dragon
            point1.transform.position = boucheDuDragon.transform.position;
            Debug.Log("point1 " + point1.transform.localPosition);

            //position du point sur les pieds du personnage
            point3.transform.position = new Vector3(perso.transform.position.x, perso.transform.position.y, perso.transform.position.z);
            //Debug.Log("point3 normalizé "+point3.transform.position.normalized);
            Debug.Log("point3 " + point3.transform.localPosition);

            // point pour créer une parabole correct
            float point2x = (Mathf.Abs(point1.transform.localPosition.x) + Mathf.Abs(point3.transform.localPosition.x)) / 2;

            float point2z = (Mathf.Abs(point1.transform.localPosition.z) + Mathf.Abs(point3.transform.localPosition.z)) / 2;

            float point2y = point1.transform.localPosition.y - 1f;
            Debug.Log("x " + point2x + "y " + point2y + "z " + point2z);


            // -- ++
            if (point1.transform.localPosition.x < 0 && point1.transform.localPosition.z < 0 && point3.transform.localPosition.x > 0 && point3.transform.localPosition.z > 0)
            {
                point2.transform.localPosition = new Vector3(point1.transform.localPosition.x + point2x, point2y, point2z);

            }
            else
            {   // ++ ++
                if (point1.transform.localPosition.x > 0 && point1.transform.localPosition.z > 0 && point3.transform.localPosition.x > 0 && point3.transform.localPosition.z > 0)
                {
                    point2.transform.localPosition = new Vector3(point2x, point2y, point2z);

                }
                else
                {   // ++ ++
                    if (point1.transform.localPosition.x > 0 && point1.transform.localPosition.z > 0 && point3.transform.localPosition.x > 0 && point3.transform.localPosition.z > 0)
                    {
                        point2.transform.localPosition = new Vector3(point2x, point2y, point2z);

                    }
                    else
                    {   // -- +-
                        if (point1.transform.localPosition.x < 0 && point1.transform.localPosition.z < 0 && point3.transform.localPosition.x > 0 && point3.transform.localPosition.z < 0)
                        {
                            point2.transform.localPosition = new Vector3(point1.transform.localPosition.x + point2x, point2y, -point2z);

                        }
                        else
                        {   // -- --
                            if (point1.transform.localPosition.x < 0 && point1.transform.localPosition.z < 0 && point3.transform.localPosition.x < 0 && point3.transform.localPosition.z < 0)
                            {
                                point2.transform.localPosition = new Vector3(-point2x, point2y, -point2z);

                            }
                            else
                            {   // +- ++
                                if (point1.transform.localPosition.x > 0 && point1.transform.localPosition.z < 0 && point3.transform.localPosition.x > 0 && point3.transform.localPosition.z > 0)
                                {
                                    point2.transform.localPosition = new Vector3(point2x, point2y, point1.transform.localPosition.z + point2z);

                                }
                                else
                                {   //+- -+
                                    if (point1.transform.localPosition.x > 0 && point1.transform.localPosition.z < 0 && point3.transform.localPosition.x < 0 && point3.transform.localPosition.z > 0)
                                    {
                                        point2.transform.localPosition = new Vector3(point1.transform.localPosition.x - point2x, point2y, point1.transform.localPosition.z + point2z);

                                    }
                                    else
                                    {   // +- --
                                        if (point1.transform.localPosition.x > 0 && point3.transform.localPosition.x < 0 && point1.transform.localPosition.z < 0 && point3.transform.localPosition.z < 0)
                                        {
                                            point2.transform.localPosition = new Vector3(-point2x, point2y, point1.transform.localPosition.z + point2z);

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sphere.SetActive(true);
            sphere.transform.position = point1.transform.position;
            lancement.EnvoyerBouleDeFeu();
        }
    }
}
