using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionPositionController : MonoBehaviour
{
    public Transform hidePoint;
    public Transform defaultPoint;

    private void Start() {
    }

    public void HideRight() {
        StartCoroutine(HideRight_Co());
        
    }
    public IEnumerator HideRight_Co() {
        while((this.transform.position.x - hidePoint.transform.position.x) < -0.001f) { //나중에 선형보간
            Vector3 temp = Vector3.Normalize(this.transform.position - hidePoint.position);
            temp *= 0.02f;
            this.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void EnterLeft() {
       StartCoroutine(EnterLeft_Co());
    }
    public IEnumerator EnterLeft_Co() {
        while((defaultPoint.transform.position.x - this.transform.position.x) < -0.001f) { //나중에 선형보간
            Vector3 temp = Vector3.Normalize(this.transform.position - defaultPoint.position);
            temp *= 0.03f;
            this.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void GoCenter() {
        StartCoroutine(GoCenter_Co());
    }
    public IEnumerator GoCenter_Co() {
        while(this.transform.position.x > 0.01f) {
            Vector3 temp = new Vector3(1,0,0);
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
            Vector3 temp = Vector3.right;
            temp *= 0.2f;
            this.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
