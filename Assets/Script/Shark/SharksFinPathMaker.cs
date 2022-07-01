using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharksFinPathMaker : MonoBehaviour
{
    public GameObject sharksFin;

    public List<Vector3> Ps = new List<Vector3>();
    public Transform a, b, c, d, e;
    [Range(0,1)]public float value;

    public Vector3 BezierTest(Vector3 _P1, Vector3 _P2, Vector3 _P3, Vector3 _P4, Vector3 _P5, float value) {
        Vector3 A = Vector3.Lerp(_P1, _P2, value);
        Vector3 B = Vector3.Lerp(_P2, _P3, value);
        Vector3 C = Vector3.Lerp(_P3, _P4, value);
        Vector3 D = Vector3.Lerp(_P4, _P5, value);

        Vector3 E = Vector3.Lerp(A, B, value);
        Vector3 F = Vector3.Lerp(B, C, value);
        Vector3 G = Vector3.Lerp(C, D, value);

        Vector3 H = Vector3.Lerp(E, F, value);
        Vector3 I = Vector3.Lerp(F, G, value);

        Vector3 J = Vector3.Lerp(H, I, value);

        return J;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // a.position = P1;
        // b.position = P2;
        // c.position = P3;
        // d.position = P4;
        // e.position = P5;
        sharksFin.transform.position = BezierCurves.Bezier(Ps, value);
        value += Time.deltaTime*0.5f;
        if(value > 1.0f) value = 0;
    }
}
