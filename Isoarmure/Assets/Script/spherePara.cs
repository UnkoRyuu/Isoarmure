using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spherePara : MonoBehaviour
{
    bool cooldown = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
    
        /*
        MouvementParabole += Time.deltaTime;
        MouvementParabole = MouvementParabole % 5f;

        transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 10f, 5f, MouvementParabole /5f);
   
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<ParabolaController>().FollowParabola();
        }
        */
    }

    public void EnvoyerBouleDeFeu()
    {
        GetComponent<ParabolaController>().FollowParabola();
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("cocuou");
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("sol") )
        {
            StartCoroutine(Dispartion());
            //disparaitre(true);                                    
        }
        
    }

    public void disparaitre(bool tempsSuffisant)
    {
        if (tempsSuffisant)
        {
            
            
        }
    }

    public IEnumerator Dispartion()
    {

        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
