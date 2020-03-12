using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCC : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Animator animEnnemi;

   // VieDuJoueur vieDuJoueur;

    protected bl_Joystick joystick;

    public float speed;
    public float jumpSpeed;
    public float gravity = 20f;
    public bool isAttacking = false;
    public bool animationSwordLance = false;
    public Transform cam;
    private Vector3 moveDirection = Vector3.zero;


    Transform from;
    Transform to;
    float rotationSpeed = 0.1f;


    CharacterController Cc;

    // Start is called before the first frame update
    void Start()
    {
       // vieDuJoueur = GetComponent<VieDuJoueur>();
        Cc = GetComponent<CharacterController>();
        joystick = FindObjectOfType<bl_Joystick>();
    }

    // Update is called once per frame
    void Update()
    {

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
        //Attack
        
        if (moveDirection.x > moveDirection.z)
        {
            anim.SetFloat("speed", moveDirection.x);
        }
        else
        {
            anim.SetFloat("speed", moveDirection.z);
        }

        if (moveDirection.x > moveDirection.z)
        {
            animEnnemi.SetFloat("speed", moveDirection.x);
        }
        else
        {
            animEnnemi.SetFloat("speed", moveDirection.z);
        }
        Debug.Log("MoveDirection : " + moveDirection);

        //Debug.Log("moveDirectionPosition Y : " + moveDirection.y);

        //Mouvement
        //Gravité
        moveDirection.y -= gravity;



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

    public bool getAnimationSwordLance()
    {
        return animationSwordLance;
    }
    public void setAnimationSwordLance(bool valueAnim)
    {
        animationSwordLance = valueAnim;
    }


    public void isSwordAttacking(int value)
    {
        if (value == 1)
        {
            setAnimationSwordLance(true);
            Debug.Log("testPositif");

        }
        else
        {
            setAnimationSwordLance(false);
            Debug.Log("testnegatif");

        }

    }

}
