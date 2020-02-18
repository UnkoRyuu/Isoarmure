using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{

    public Animator anim;
    public float speed = 8f;
    public float gravity = 20f;
    public bool isAttacking = false;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController Cc;

    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animation Déplacement
        if (Cc.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        //Animation Attack
        /*anim.SetBool("isAttacking", false);
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }*/


        //Mouvement
        //Gravité
        if (!Cc.isGrounded)
        {
            Debug.Log("isNotGrounded");
            moveDirection.y -= gravity * Time.deltaTime;
        }
        //moveDirection.y -= gravity * Time.deltaTime;

        Debug.Log("moveDirectionPosition Y : " + moveDirection.y);
        

        //Rotation du personnage
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 1000);
        
        //Application du mouvement
        Cc.Move(moveDirection * Time.deltaTime);
    }
}
