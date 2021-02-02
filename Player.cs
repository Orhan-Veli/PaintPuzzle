using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public GameObject gun;
    Rigidbody myRig;
    public float moveGun=3f;
    FixedJoystick joyStick;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Drag.instance.IsDone)
        {
            myRig = gun.GetComponent<Rigidbody>();
            joyStick = GameObject.FindWithTag("joystick").GetComponent<FixedJoystick>();
            //joyStick.enabled = true;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        myRig.velocity = new Vector3(joyStick.Horizontal * moveGun, joyStick.Vertical*moveGun, myRig.velocity.z);
    }
}
