using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScratch : MonoBehaviour
{
    public GameObject lionArm;
    public LionPositionController lionPosCon;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        lionArm.transform.SetParent(lionPosCon.transform);
        lionArm.transform.localPosition = new Vector3(-4,0,0);
        animator = lionArm.gameObject.GetComponent<Animator>();
        StartCoroutine(Scratch());
    }

    IEnumerator Scratch() {
        animator.SetTrigger("up1");
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("up1");
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("up1");
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("up1");
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("up1");
        yield return StartCoroutine(lionPosCon.MoveLeftLittle());
        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(lionPosCon.HideRight_Co());
        yield return StartCoroutine(lionPosCon.EnterLeft_Co());

        lionArm.SetActive(false);
    }
}
