using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{

    public Animator anim;

    protected bl_Joystick joystick;

    public float speed = 8f;
    public float jumpSpeed;
    public float gravity = 20f;
    public bool isAttacking = false;
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
        

        //Animation Déplacement
        if (Cc.isGrounded)
        {
            moveDirection = new Vector3(joystick.Horizontal * 0.125f, moveDirection.y, joystick.Vertical * 0.125f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
        }
        

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
