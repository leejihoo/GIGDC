using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //transform.position = this.transform.position + Vector3.right;   
        transform.Translate(15f*Time.deltaTime,0,0);
    }
}
