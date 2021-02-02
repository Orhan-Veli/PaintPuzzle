using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript1 : MonoBehaviour
{
    public static PlaneScript1 instance;
    public Sprite[] mySplashes;
    public GameObject SplashPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Drag.instance.IsDone && transform.position.y != -90)
        {
            if (transform.position.y <= -90)
            {
                transform.position += transform.up * Time.deltaTime*50;
            }
            else
            {
                transform.position = new Vector3(transform.position.x,-90,transform.position.z);
            }
        }  
    }
    public void SpriteCreater(Vector3 point,GameObject balon)
    {
        point.z -= 10;
        GameObject temp = Instantiate(SplashPrefab, point, Quaternion.identity);
        temp.transform.eulerAngles = new Vector3(0, 0, 0);
        temp.GetComponent<SpriteRenderer>().sprite = mySplashes[Random.Range(0,mySplashes.Length)];
        //temp.GetComponent<SpriteRenderer>().color = GameController.instance.currentColor;
        temp.GetComponent<SpriteRenderer>().color = balon.GetComponent<BaloonScript>().myColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baloon")
        {
            Destroy(collision.gameObject);
            SpriteCreater(collision.contacts[0].point,collision.gameObject);    
        }
    }
}
