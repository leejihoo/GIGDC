using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5.0f) Destroy(this.gameObject); //아니면 나중에 setactive(false)하고 재활용.
    }
}
