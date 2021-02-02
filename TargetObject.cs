using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public static TargetObject instance;
    public int targetInt = 0;
    private void Awake()
    {
        instance = this;
    }
}
