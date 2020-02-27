using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    protected bl_Joystick joystick;

    public float speed = 1f;
    public float jumpSpeed;
    public float gravity = 20f;
    public bool isAttacking = false;
    private Vector3 moveDirection = Vector3.zero;


    Transform from;
    Transform to;
    float rotationSpeed = 0.1f;


    CharacterController Cc;

    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
        joystick = FindObjectOfType<bl_Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        */
        //Animation Déplacement
        if (Cc.isGrounded)
        {
            moveDirection = new Vector3(joystick.Horizontal * 0.125f +Input.GetAxis("Horizontal") * 0.5f, moveDirection.y, joystick.Vertical * 0.125f + Input.GetAxis("Vertical") * 0.5f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
        }
        //Attack
        /*if (Input.GetButton("Fire1"))
        {
            anim.Play("Attack");
        }*/

        anim.SetFloat("vertical", joystick.Vertical * 0.125f);
        anim.SetFloat("horizontal", joystick.Horizontal * 0.125f);

        //Debug.Log("moveDirectionPosition Y : " + moveDirection.y);

        //Mouvement
        //Gravité
        moveDirection.y -= gravity;


        //Rotation du personnage
        //transform.Rotate(Vector3.up * joystick.Horizontal * Time.deltaTime * speed * 200);
        //transform.rotation = Quaternion.Lerp(moveDirection.x, moveDirection.z, Time.time * rotationSpeed);


        //Application du mouvement
        Cc.Move(moveDirection * Time.deltaTime);

        //Debug.Log(Cc.isGrounded);
        Debug.Log(Cc.isGrounded);
    }

    //Animation Attack
    public void Attack()
    {
        anim.Play("Attack");      
    }

    public void Jump()
    {
        if (Cc.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            Debug.Log("SAUT");
        }
        else
        {
            Debug.Log("Saut Not Grounded");
        }
    }




    /*
     
      Transform from;
    Transform to;
    float speed = 0.1f;
    void Update()
    {
        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
    }
     
     */
}
