using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNumber : MonoBehaviour
{
    static public StageNumber instance;
    static public int CurrentStage =4;
    // Start is called before the first frame update
    void Start()
    {
        if (instance = null)
        {
            instance = new StageNumber();
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
