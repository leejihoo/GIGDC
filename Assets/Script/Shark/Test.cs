using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : SkillModel
{
    public GameObject[] waves;

    void Start() {
        StartCoroutine(ClickAnim());
    }

    IEnumerator ClickAnim() {
        var wait = new WaitForSeconds(0.3f);
        for(int i = 0; i < 5; i++) {
            GameObject wave = GameObject.Instantiate(waves[i%2]) as GameObject;
            wave.transform.rotation = shark.transform.rotation;
            wave.transform.position = shark.transform.position;

            yield return wait;
        }
        bossController_Shark.EndSkillPlaying();
    }
}
