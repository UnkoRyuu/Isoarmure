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
        rigibody.velocity = new Vector3(Input.GetAxis("Horizontal") * 10f , rigibody.velocity.y, Input.GetAxis("Vertical") * 10f);

        anim.SetFloat("vertical", Input.GetAxis("Vertical") * 10f);
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal") * 10f);
    }
}
