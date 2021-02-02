using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public FixedJoystick myJoyStick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Drag.instance.IsDone && transform.position.z != -550)
        {
            if (transform.position.z >= -550)
            {
                transform.position -= transform.forward * Time.deltaTime * 100f;

            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -550);
            }
        }
    }
}
