using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject[] waves;

    public void Click() {
        StartCoroutine(ClickAnim());
    }

    IEnumerator ClickAnim() {
        var wait = new WaitForSeconds(0.3f);
        for(int i = 0; i < 5; i++) {
            GameObject wave = GameObject.Instantiate(waves[i%2]) as GameObject;
            wave.transform.position = new Vector3(0,0,0);

            yield return wait;
        }
    }
}
