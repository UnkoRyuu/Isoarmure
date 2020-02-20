using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{

    public Animator anim;

    protected bl_Joystick joystick;

    public float speed = 8f;
    public float jumpSpeed = 0.001f;
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
            moveDirection = new Vector3(0, 0, joystick.Vertical * 0.125f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed * 0.05f;
                Debug.Log("SAUT");
            }
        }
        

        anim.SetFloat("vertical", joystick.Vertical * 0.125f);
        anim.SetFloat("horizontal", joystick.Horizontal * 0.125f);

        Debug.Log("moveDirectionPosition Y : " + moveDirection.y);

        //Animation Attack
        /*anim.SetBool("isAttacking", false);
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }*/


        //Mouvement
        //Gravité
        moveDirection.y -= gravity * Time.deltaTime;
        

        //Rotation du personnage
        transform.Rotate(Vector3.up * joystick.Horizontal * Time.deltaTime * speed * 200);
        
        //Application du mouvement
        Cc.Move(moveDirection * Time.deltaTime);
    }
}
