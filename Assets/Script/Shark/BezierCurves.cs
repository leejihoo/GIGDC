using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurves
{
    public static Vector3 Bezier(List<Vector3> points, float value) {
        List<Vector3> step1 = points.ToList();
        int temp;
        int pastTemp = 0;
        for(int i = 1; i < points.Count; i++) {
            temp = step1.Count;
            for(int j = pastTemp; j < temp-1; j++) {
                step1.Add(Vector3.Lerp(step1[j], step1[j+1], value));
            }
            pastTemp = temp;
        }

        return step1.Last();
    }
}
