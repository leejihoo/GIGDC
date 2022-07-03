using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharksFin : MonoBehaviour
{
    int rotate = 0;
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0,0, rotate);
        rotate++;
    }
}
