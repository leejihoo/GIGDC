using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScratch : MonoBehaviour
{
    public GameObject lionArm;
    public LionPositionController lionPosCon;

    // Start is called before the first frame update
    void Start()
    {
        lionArm.transform.SetParent(lionPosCon.transform);
        lionArm.transform.localPosition = new Vector3(4,0,0);
        StartCoroutine(Scratch());
    }

    IEnumerator Scratch() {
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.3f);
    }
}
