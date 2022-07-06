using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBladecaller : SkillModel
{
    private float _speed;
    private bool _isCalled;
    private bool _isStarted;
    private bool _isCurved;
    static private bool _isDelay;

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
        _isDelay = false;



    }

    public void FlyingFeathers()
    {

    }

    public void Bladecaller()
    {
        var target = GameObject.Find("ControlPoint");
        Vector2 dirForwardBoss = target.transform.position - this.transform.position;
        
        transform.Translate(dirForwardBoss.normalized * Time.deltaTime * _speed);
        
        if (dirForwardBoss.magnitude <= 0.1f)
        {

            //Debug.Log(dirForwardBoss.magnitude);
            GameObject.Find("Eagle").GetComponent<EagleSkill>().SkillRunnig = false;
            if (!_isDelay)
            {
                _isDelay = true;
                GameObject.Find("Eagle").GetComponent<EagleSkill>().IsDelay = false;
            }
            GameObject.Find("Eagle").GetComponent<Animator>().SetBool("IsFeatherBladeOn", false);

            _isCalled = false;
            _isCurved = false;
            _isStarted = false;
            this.GetComponent<SpriteRenderer>().flipX = false;
            GameObject.Find("Eagle").GetComponent<AudioSource>().Stop();
            gameObject.SetActive(false);
        }
    }

    IEnumerator WaitCalling()
    {
        _isStarted = true;
        yield return new WaitForSeconds(5);
        GameObject.Find("Eagle").GetComponent<AudioSource>().Play();
        this.GetComponent<SpriteRenderer>().flipX = true;
        _isCalled = true;
    }

    private void Update()
    {
        if (!_isCalled)
        {
            _isDelay = false;
        }
        else
        {
            Bladecaller();
        }

        if (!_isCurved && gameObject.activeSelf)
        {
            _isCurved = true;
            StartCoroutine(Curve());
        }

        if (!_isStarted && gameObject.activeSelf)
        {
            StartCoroutine(WaitCalling());
        }
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
        
        foreach(var item in curvePoints)
        {
            
            this.transform.position = item;
            yield return new WaitForEndOfFrame();
            
        }
        
    }

    public override void Cast()
    {
        pointA = GameObject.Find("ControlPoint").transform.position;
        //pointC = GameObject.Find("Player").transform.position;
        pointC = Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), -Camera.main.transform.position.z));
        pointB = new Vector3(Random.Range(pointA.x, pointC.x), Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0)).y, 0);
        CalculateCurvePoints(200);
    }
}
