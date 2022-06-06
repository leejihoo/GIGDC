using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAssassination : SkillModel
{
    private float _speed;
    private Vector3 _playerPos;

    private bool _isStart;
    private bool _firstTargetPosition;
    private bool _secondTargetPosition;
    private bool _thirdTargetPosition;
    private bool _finalTargetPosition;

    private Vector3 _dir;
    //private Vector3 _secondDir;
    //private Vector3 _thirdir;
    public CatAssassination()
    {
        Name = "CatAssassination";
        IsCanParrying = true;
        _speed = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("PlayerSpotLight").SetActive(false);
        GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStart)
        {
            StartCoroutine(AttackOrder());
        }

        _dir = _playerPos - GameObject.Find("Cat").transform.position;
        
        if (_dir.magnitude >= 0.1f )
        {
            this.transform.parent.transform.Translate(_dir.normalized * Time.deltaTime * _speed);
        }

        //var secondDir = _playerPos - GameObject.Find("Cat").transform.position;
        //if (secondDir.magnitude >= 0.1f && !_secondTargetPosition)
        //{
        //    this.transform.parent.transform.Translate(secondDir.normalized * Time.deltaTime * _speed);
        //}

        //if (secondDir.magnitude < 0.1f)
        //{
        //    _secondTargetPosition = true;
        //    _playerPos = GameObject.Find("Player").transform.position;
        //}

        //var thirdDir = _playerPos - GameObject.Find("Cat").transform.position;
        //if (thirdDir.magnitude >= 0.1f && !_secondTargetPosition)
        //{
        //    this.transform.parent.transform.Translate(thirdDir.normalized * Time.deltaTime * _speed);
        //}

        //if (thirdDir.magnitude < 0.1f)
        //{
        //    _thirdTargetPosition = true;
        //}
    }

    public override void Cast()
    {
        
        GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator AttackOrder()
    {
        _isStart = true;
        
        for(int i = 0; i<3; i++)
        {
            _playerPos = GameObject.Find("Player").transform.position;
            yield return new WaitForSeconds(3);
        }
    }

    public void TrackPlayer()
    {

    }
}
