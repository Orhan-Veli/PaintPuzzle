using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndShoot : MonoBehaviour
{
    Vector3 pos;
    public GameObject myBaloon;
   float speed=700;
    public AudioSource ShootSound;
    // Start is called before the first frame update
    void Start()
    {
        ShootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBaloon();
        }
    }
    public void SpawnBaloon()
    {
        if (Drag.instance.IsDone)
        {
            ShootSound.Play();
                pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject Baloon = Instantiate(myBaloon, pos, transform.rotation);
                Baloon.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
           
        }
    }
}



