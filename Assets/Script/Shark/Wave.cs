using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    float speed = -0.03f;
    void Update()
    {
        this.transform.Translate(speed,0,0);
    }

}
