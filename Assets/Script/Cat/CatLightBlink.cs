using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLightBlink : MonoBehaviour
{
    Blink blink;
    public CatLightBlink()
    {
        blink = new Blink();
    }
    // Update is called once per frame
    void Update()
    {
        blink.Work(0.2f, 0f, 0.001f, this.gameObject);
    }
}
