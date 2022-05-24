using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBladecaller : SkillModel
{
    private float _speed;
    private bool _isCalled;
    private bool _isStarted;

    public EagleBladecaller()
    {
        Name = "Bladecaller";
        Damage = 1;
        IsCanParrying = true;
        HoldingTime = 3;
        _speed = 5;
        _isCalled = false;
        _isStarted = false;
    }

    public void FlyingFeathers()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * _speed);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
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
        yield return new WaitForSeconds(3);
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

        if (!_isStarted)
        {
            StartCoroutine(WaitCalling());
        }


    }

    
}
