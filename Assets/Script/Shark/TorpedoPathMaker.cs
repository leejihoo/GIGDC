using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoPathMaker : MonoBehaviour
{
    public GameObject torpedo;
    public GameObject dummy;
    public GameObject defaultPoint;

    public void LaunchTorpedo() {
        GameObject newTorpedo = GameObject.Instantiate(torpedo);
        newTorpedo.transform.position = defaultPoint.transform.position;
        newTorpedo.GetComponent<Torpedo>().Launch(dummy.transform.position);
    }
}


