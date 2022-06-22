using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightBlink : MonoBehaviour
{
    Blink blink;
    public PlayerLightBlink()
    {
        blink = new Blink();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blink.Work(1f,0.5f,0.002f,this.gameObject);
    }
}
