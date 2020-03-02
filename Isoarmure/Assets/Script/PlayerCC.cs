using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCC : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    protected bl_Joystick joystick;

    public float speed = 1f;
    public float jumpSpeed;
    public float gravity = 20f;
    public bool isAttacking = false;
    public Transform cam;
    private Vector3 moveDirection = Vector3.zero;

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
        float inputX = joystick.Horizontal * 0.125f + Input.GetAxis("Horizontal") * 0.5f;
        float inputY = joystick.Vertical * 0.125f + Input.GetAxis("Vertical") * 0.5f;
        Vector3 inputVector = new Vector3(inputX, inputY, 0);

        //Animation Déplacement
        if (Cc.isGrounded)
        {
            Vector3 forwardTarget = new Vector3(cam.forward.x, 0, cam.forward.z);
            Vector3 forwardDirection = forwardTarget;
            forwardDirection = forwardDirection.normalized;
            //Debug.DrawLine(cam.position, cam.position + forwardDirection, Color.magenta);

            Vector3 rightTarget = new Vector3(cam.right.x, 0, cam.right.z);
            Vector3 rightDirection = rightTarget;
            rightDirection = rightDirection.normalized;
            //Debug.DrawLine(cam.position, cam.position + rightDirection, Color.red);

            Vector3 move = forwardDirection * inputY + rightDirection * inputX;

            moveDirection = new Vector3(move.x * speed, moveDirection.y, move.z * speed);
            
        }
        

        /*if(moveDirection != new Vector3(0, 0, 0)
        {
            anime.
        }*/
        anim.SetFloat("vertical", joystick.Vertical * 0.125f);
        anim.SetFloat("vertical", joystick.Horizontal * 0.125f);

        //Debug.Log("moveDirectionPosition Y : " + moveDirection.y);

        //Mouvement
        //Gravité
        moveDirection.y -= gravity;
        

        //Rotation du personnage
        //transform.Rotate(Vector3.up * joystick.Horizontal * Time.deltaTime * speed * 200);
        
        //Application du mouvement
        Cc.Move(moveDirection * Time.deltaTime);

        
        if(inputVector.magnitude > 0.1f)
        {
            Vector3 rotTarget = new Vector3(moveDirection.x, 0, moveDirection.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)), 0.1f);
        }
            

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
}
