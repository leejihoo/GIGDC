using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Blinking : MonoBehaviour
{
    private bool _isSwitch;
    
    public Blinking()
    {
        _isSwitch = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<Light2D>().intensity > 0.5 && _isSwitch)
        {
            this.gameObject.GetComponent<Light2D>().intensity -= 0.002f;
        }
        else
        {
            _isSwitch = false;
            this.gameObject.GetComponent<Light2D>().intensity += 0.002f;
            
            if(this.gameObject.GetComponent<Light2D>().intensity > 1) 
            {
                _isSwitch = true;
            }
        }
    }
}
