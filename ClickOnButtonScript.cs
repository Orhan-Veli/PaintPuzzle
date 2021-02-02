using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnButtonScript : MonoBehaviour
{
    Vector3 pos;
    public GameObject myBaloon;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ClickSpawnBaloon() {
        if (Drag.instance.IsDone)
        {
            pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject Baloon = Instantiate(myBaloon, pos, transform.rotation);
            Baloon.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
    }
}

