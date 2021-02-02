using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baloon")
        {
            Destroy(collision.gameObject);
        }
    }
}
