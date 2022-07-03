using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMover : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0.0f;
    float xPositive = 0.02f;

    void Update()
    {
        this.gameObject.transform.Translate(xPositive,0,0);
        timer += Time.deltaTime;
        if(timer > 1.0f) {
            timer = 0;
            xPositive *= -1;
        }
    }
}
