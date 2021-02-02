using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    public static CollisionObject instance;
    public int baloonIntColor = 0;
    public void Awake()
    {
        instance = this;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baloon")
        {
            gameObject.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<BaloonScript>().myColor;
            baloonIntColor = collision.gameObject.GetComponent<BaloonScript>().myInt;
            Destroy(collision.gameObject);
        }
    }

}
