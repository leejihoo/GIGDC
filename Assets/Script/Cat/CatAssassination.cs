using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CatAssassination : SkillModel
{
    private float _speed;
    private Vector3 _playerPos;
    private Vector3 _firstPosition;
    private bool _isStart;

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
        //GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStart)
        {
            StartCoroutine(AttackOrder());
        }

        //if (GameObject.Find("GlobalLight").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity >= 0)
        //{
        //    GameObject.Find("GlobalLight").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= 0.002f;
        //}
        //else
        //{
            _dir = _playerPos - GameObject.Find("Cat").transform.position;

            if (_dir.magnitude >= 0.1f)
            {
                this.transform.parent.transform.Translate(_dir.normalized * Time.deltaTime * _speed);
            }
        //}
        

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
        
        gameObject.transform.SetParent(GameObject.Find("Cat").transform);
        gameObject.transform.localPosition = Vector3.zero;
        _firstPosition = GameObject.Find("Cat").transform.position;
        _isStart = false;
        //GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator AttackOrder()
    {
        _isStart = true;
        
        for(int i = 0; i<3; i++)
        {
            _playerPos = GameObject.Find("Player").transform.position;
            yield return new WaitForSeconds(3);
        }
        GameObject.Find("Cat").GetComponent<CatSkill>().SkillRunnig = false;
        GameObject.Find("Cat").GetComponent<CatSkill>().IsDelay = false;
        GameObject.Find("Cat").transform.position = _firstPosition + new Vector3(20, 0, 0);
        yield return new WaitForSeconds(1);
        GameObject.Find("Cat").transform.position = _firstPosition;
        //GameObject.Find("GlobalLight").GetComponent<Light2D>().intensity = 1;
        gameObject.SetActive(false);
    }

    public void TrackPlayer()
    {

    }
}
