using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharksFinPathMaker : SkillModel
{
    public GameObject sharksFin;
    public List<Vector3> Ps = new List<Vector3>();
    [Range(0,1)]public float value;

    private int count = 0;

    void Update()
    {
        sharksFin.transform.position = BezierCurves.Bezier(Ps, value);
        value += Time.deltaTime*0.5f;
        if(value > 1.0f) {
            value = 0;
            count++;
            if(count == 5) {
                bossController_Shark.EndSkillPlaying();
                Destroy(this.gameObject);
            }
        }
    }
}
