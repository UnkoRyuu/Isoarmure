using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    protected bl_Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<bl_Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigibody = GetComponent<Rigidbody>();
        rigibody.velocity = new Vector3(joystick.Horizontal *0.1f , rigibody.velocity.y, joystick.Vertical * 0.1f  );
    }
}
