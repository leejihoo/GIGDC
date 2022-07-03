using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailForToken : MonoBehaviour
{
    static public EmailForToken instance;
    public string KeyForToken;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}
