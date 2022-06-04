using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSonicBoom : SkillModel
{
    private float _speed;
    private bool _firstTargetPosition;
    private bool _secondTargetPosition;
    private bool _thirdTargetPosition;
    private bool _finalTargetPosition;
    public EagleSonicBoom()
    {
        _speed = 10;
    }

    public override void Cast()
    {
        //this.transform.parent.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0.9f, -Camera.main.transform.position.z));
    }
    // Update is called once per frame
    void Update()
    {

        var firstDir = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.9f, -Camera.main.transform.position.z)) - GameObject.Find("Eagle").transform.position;
        if (firstDir.magnitude >= 0.1f && !_firstTargetPosition)
        {
            this.transform.parent.transform.Translate(firstDir.normalized * Time.deltaTime * _speed);
        }
        else
        {
            _firstTargetPosition = true;
        }

        var secondDir = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0.1f, -Camera.main.transform.position.z)) - GameObject.Find("Eagle").transform.position;
        if (secondDir.magnitude >= 0.1f && !_secondTargetPosition && _firstTargetPosition)
        {
            this.transform.parent.transform.Translate(secondDir.normalized * Time.deltaTime * _speed);
        }
        
        if(secondDir.magnitude < 0.1f)
        {
            _secondTargetPosition = true;
        }

        //var thirdDir = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, -Camera.main.transform.position.z)) - GameObject.Find("Eagle").transform.position;
        //if (thirdDir.magnitude >= 0.1f && !_thirdTargetPosition && _secondTargetPosition)
        //{
        //    this.transform.parent.transform.Translate(thirdDir.normalized * Time.deltaTime * _speed);
        //}
        //else
        //{
        //    _thirdTargetPosition = true;
        //}

        //var finalDir = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.9f, -Camera.main.transform.position.z)) - GameObject.Find("Eagle").transform.position;
        //if (finalDir.magnitude >= 0.1f && !_finalTargetPosition && _thirdTargetPosition)
        //{
        //    this.transform.parent.transform.Translate(finalDir.normalized * Time.deltaTime * _speed);
        //}
        //else
        //{
        //    _finalTargetPosition = true;
        //}
    }
}