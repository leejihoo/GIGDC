using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    float speed = -3f;
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime,0,0);
    }

}
