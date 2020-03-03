using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fieldOfview : MonoBehaviour
{
    private Animator anim;

    public Image danger;
    public float silent = 0f;
    public float viewRadius;
    float positionX_Player = 0, positionZ_Player = 0, positionX_dragon = 0, positionZ_dragon = 0;
    //public float viewAngle;
    public GameObject player; 
    public GameObject dragon ;

    public Vector3 DirFromAngle(float anglesinDegrees)
    {
        return new Vector3(Mathf.Sin(anglesinDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(anglesinDegrees * Mathf.Deg2Rad));
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dragon = GameObject.FindGameObjectWithTag("Dragon");
    }
    public void Update()
    {
        detection();

    }
    public void detection()
    {
        positionX_Player = player.transform.position.x;
        positionZ_Player = player.transform.position.z;
        positionX_dragon = dragon.transform.position.x;
        positionZ_dragon = dragon.transform.position.z;

        //Debug.Log(positionX_dragon + " , " + positionZ_dragon);
        //Debug.Log(positionX_Player + " , " + positionZ_Player);
        //Debug.Log(Mathf.Pow(5, 2));

        //calcule de distance entre les points
        float distance = Mathf.Sqrt(Mathf.Pow(positionX_dragon - positionX_Player, 2) + Mathf.Pow(positionZ_dragon - positionZ_Player, 2));
        //Debug.Log(distance);
        if (distance <= viewRadius)
        {
            danger.gameObject.SetActive(true);
            anim.SetBool("inZone", true);
            anim.SetFloat("randomAttack", Random.Range(0.00001f, 3));
            //anim.SetFloat("randomAttack", -1f);
        }
        else
        {
            danger.gameObject.SetActive(false);
            anim.SetBool("inZone", false);
            anim.SetFloat("randomAttack", Random.Range(0.00001f, 2));
            //anim.SetFloat("randomAttack", -1f);
        }
    }
        
   
}
