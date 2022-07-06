using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionPositionController : Boss
{
    public Transform hidePoint;
    public Transform defaultPoint;

    private void Start() {
        Application.targetFrameRate = 60;
    }

    public void HideRight() {
        StartCoroutine(HideRight_Co());
        
    }
    public IEnumerator HideRight_Co() {
        while(Mathf.Abs(this.transform.position.x - hidePoint.transform.position.x) > 0.1f) { //나중에 선형보간
            Vector3 temp = Vector3.Normalize(hidePoint.position - this.transform.position);
            temp *= 7f*Time.deltaTime;
            this.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        this.transform.position = hidePoint.transform.position;
    }

    public void EnterLeft() {
       StartCoroutine(EnterLeft_Co());
    }
    public IEnumerator EnterLeft_Co() {
        while(Mathf.Abs(defaultPoint.transform.position.x - this.transform.position.x) > 0.1f) { //나중에 선형보간
            Vector3 temp = Vector3.Normalize(defaultPoint.position - this.transform.position);
            temp *= 10f*Time.deltaTime;
            this.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        this.transform.position = defaultPoint.transform.position;
    }

    public void GoCenter() {
        StartCoroutine(GoCenter_Co());
    }
    public IEnumerator GoCenter_Co() {
        while(this.transform.position.x > 0.01f) {
            Vector3 temp = Vector3.left;
            temp *= 0.5f;
            this.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public IEnumerator MoveLeftLittle() {
        Vector3 currentPos = Camera.main.WorldToViewportPoint(this.transform.position);
        Debug.Log(currentPos);
        Vector3 left = Camera.main.ViewportToWorldPoint(currentPos - Vector3.one*0.1f);
        Debug.Log(left);

        while(left.x - this.transform.position.x < -0.001f) {
            Vector3 temp = Vector3.left;
            temp *= 0.2f;
            this.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
