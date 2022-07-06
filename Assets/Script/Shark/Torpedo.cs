using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    Vector3 targetPoint;
    public GameObject shark;
    public GameObject boom;

    // Start is called before the first frame update
    public void Launch(Vector3 target) {
        targetPoint = target;
        StartCoroutine(LaunchOwn());
    }

   IEnumerator LaunchOwn() {
        float value = 0.0f;
        Vector3 startPoint = this.transform.position;
        Vector3 destPoint = targetPoint;
        Vector3 midPoint = (startPoint + destPoint) / 2;

        float slope = -1 * ((startPoint.x - destPoint.x) / (startPoint.y - destPoint.y));
        float intercept = -1*slope*midPoint.x + midPoint.y;
        
        float x = Random.Range(((startPoint + midPoint)/2).x, startPoint.x);
        //float x = Random.Range(midPoint.x, startPoint.x);
        float y = -1*(slope*x+intercept)/2;
        float r = ((Random.Range(1, 10)%2 == 0) ? -0.1f : 0.1f);
        Vector3 interPoint = new Vector3(x, r * y, 0);
        List<Vector3> vecList = new List<Vector3>{startPoint, interPoint, destPoint};

        while(value < 1.0f) {
            this.transform.position = BezierCurves.Bezier(vecList, value);
            value += Time.deltaTime*1f;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        shark.SetActive(false);
        boom.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        boom.SetActive(false);
        Destroy(this.gameObject);
    }
}
