using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    protected bl_Joystick joystick;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<bl_Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigibody = GetComponent<Rigidbody>();
        rigibody.velocity = new Vector3(joystick.Horizontal * 2f , rigibody.velocity.y, joystick.Vertical * 2f);
        Debug.Log(joystick.Horizontal);
        /*
        anim.SetFloat("vertical", Input.GetAxis("Vertical") * 10f);
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal") * 10f);
    */
    }
}
