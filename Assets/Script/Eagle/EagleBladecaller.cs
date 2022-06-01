using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBladecaller : SkillModel
{
    private float _speed;
    private bool _isCalled;
    private bool _isStarted;

    private bool _isCurved;
    private int _count;

    public EagleBladecaller()
    {
        Name = "Bladecaller";
        Damage = 1;
        IsCanParrying = true;
        HoldingTime = 3;
        _speed = 10;
        _isCalled = false;
        _isStarted = false;
        _isCurved = false;

        _count = 0;
        
    }

    public void FlyingFeathers()
    {
        //var result = Vector3.Slerp(transform.position, GameObject.Find("Player").transform.position, 0.01f) ;
        //transform.position = result;
        //transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * _speed);

        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //if (pos.x < 0f) pos.x = 0f;
        //if (pos.x > 1f) pos.x = 1f;
        //if (pos.y < 0f) pos.y = 0f;
        //if (pos.y > 1f) pos.y = 1f;
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    public void Bladecaller()
    {
        var target = GameObject.FindGameObjectWithTag("Eagle");
        Vector3 dirForwardBoss = target.transform.position - this.transform.position;
        
        transform.Translate(dirForwardBoss.normalized * Time.deltaTime * _speed);

    }

    IEnumerator WaitCalling()
    {
        _isStarted = true;
        yield return new WaitForSeconds(5);
        Debug.Log("wait");
        _isCalled = true;
    }

    private void Update()
    {
        if (!_isCalled)
        {
            FlyingFeathers();
        }
        else
        {
            Bladecaller();
        }

        if (!_isCurved)
        {
            _isCurved = true;
            StartCoroutine(Curve());
        }

        if (!_isStarted)
        {
            StartCoroutine(WaitCalling());
        }


    }

    private void Start()
    {
        pointA = GameObject.Find("Eagle").transform.position;
        //pointC = GameObject.Find("Player").transform.position;
        pointC = Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0));
        
        pointB = new Vector3(Random.Range(pointA.x, pointC.x), Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0)).y, 0);
        CalculateCurvePoints(75);
    }
        
    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 pointC;
    private Vector3[] curvePoints;

    /// <summary> 베지어 커브 내의 지점들 미리 계산 </summary>
    private void CalculateCurvePoints(int count)
    {
        Vector3 pA = pointA;
        Vector3 pB = pointB;
        Vector3 pC = pointC;

        curvePoints = new Vector3[count + 1];
        float unit = 1.0f / count;

        int i = 0; float t = 0f;
        for (; i < count + 1; i++, t += unit)
        {
            float u = (1 - t);
            float t2 = t * t;
            float u2 = u * u;

            curvePoints[i] =
                pA * u2 +
                pB * (t * u * 2) +
                pC * t2
            ;
        }
    }

    IEnumerator Curve()
    {
        int a = 0;
        foreach(var item in curvePoints)
        {
            Debug.Log(item);
            
            this.transform.position = item;
            yield return new WaitForEndOfFrame();
            
        }
    }
}
