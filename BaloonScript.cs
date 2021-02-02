using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonScript : MonoBehaviour
{
    public Color myColor;
    public int myInt;
    public void Start()
    {
        myColor = GameController.instance.currentColor;
        myInt = GameController.instance.ColorObject;
    }
}
