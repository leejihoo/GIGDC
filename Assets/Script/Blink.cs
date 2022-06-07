using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Blink : MonoBehaviour
{
    private bool _isSwitch;
    
    public Blink()
    {
        _isSwitch = true;
    }

    public void Work(float maxLimitIntensity, float minLimitIntensity, float change, GameObject gameObject)
    {
        if (gameObject.GetComponent<Light2D>().intensity > minLimitIntensity && _isSwitch)
        {
            gameObject.GetComponent<Light2D>().intensity -= change;
        }
        else
        {
            _isSwitch = false;
            gameObject.GetComponent<Light2D>().intensity += change;

            if (gameObject.GetComponent<Light2D>().intensity > maxLimitIntensity)
            {
                _isSwitch = true;
            }
        }
    }
}
