using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoPathMaker : SkillModel
{
    public GameObject torpedo;

    private void Start() {
        StartCoroutine(LaunchTorpedo());
    }

    IEnumerator LaunchTorpedo() {
        for(int i = 0; i < 7; i++) {
            GameObject newTorpedo = GameObject.Instantiate(torpedo);
            newTorpedo.transform.position = defaultPoint.transform.position;
            newTorpedo.GetComponent<Torpedo>().Launch(dummy.transform.position);
            yield return new WaitForSeconds(0.2f);
        }
        bossController_Shark.EndSkillPlaying();
    }
}


