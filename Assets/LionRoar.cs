using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionRoar : MonoBehaviour
{
    public LionPositionController lionPosCon; // 나중엔 StageGeneralManager가 LionRoar Instantiate하면서 LionPosCon지정해주기.
    public GameObject roar;

    private void Start() {
        StartCoroutine(Roar());
    }

    IEnumerator Roar() {
        yield return lionPosCon.GoCenter_Co();

        yield return new WaitForSeconds(0.3f);

        GameObject newRoar = GameObject.Instantiate(roar);
        newRoar.transform.position = new Vector3(0,0,-1);

        yield return new WaitForSeconds(1.5f);

        yield return lionPosCon.HideRight_Co();

        yield return lionPosCon.EnterLeft_Co();
    }
}
