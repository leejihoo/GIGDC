using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDatabase : MonoBehaviour
{
    public static StageDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    public List<StageInfo> stage = new List<StageInfo>();
}
