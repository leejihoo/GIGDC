using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CatChattering : SkillModel
{
    private float _speed;
    private bool _skillRunning;
    private Vector3 _firstPosition;

    public CatChattering()
    {
        Name = "Chattering";    
    }

    // Update is called once per frame
    void Update()
    {

        if (!_skillRunning)
        {
            //if (GameObject.Find("GlobalLight").GetComponent<Light2D>().intensity >= 0)
            //{
            //    GameObject.Find("GlobalLight").GetComponent<Light2D>().intensity -= 0.002f;
            //}
            //else
            //{
                //GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
                //GameObject.Find("Cat").transform.GetChild(2).gameObject.SetActive(true);
                var _dir = GameObject.Find("Player").transform.position - GameObject.Find("Cat").transform.position;

                if (_dir.magnitude >= 0.1f)
                {
                    GameObject.Find("Cat").transform.Translate(_dir.normalized * Time.deltaTime * _speed);
                }
            //} 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _speed = 10;
        }
    }

    public override void Cast()
    {
        _speed = 3;
        //gameObject.transform.SetParent(GameObject.Find("Cat").transform);
        //gameObject.transform.localPosition = Vector3.zero;
        _firstPosition = GameObject.Find("Cat").transform.position;
        _skillRunning = false;
        StartCoroutine(ContinueSkill());
        
    }

    IEnumerator ContinueSkill()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("Cat").GetComponent<CatSkill>().SkillRunnig = false;
        GameObject.Find("Cat").GetComponent<CatSkill>().IsDelay = false;
        _skillRunning = true;
        GameObject.Find("Cat").transform.position = _firstPosition + new Vector3(20,0,0);
        yield return new WaitForSeconds(1);

        GameObject.Find("Cat").transform.position = _firstPosition; 

        //GameObject.Find("GlobalLight").GetComponent<Light2D>().intensity = 1;
        GameObject.Find("Cat").GetComponent<Animator>().SetBool("IsChatteringOn", false);
        GameObject.Find("Cat").GetComponent<AudioSource>().Stop();
        gameObject.SetActive(false);
    }

}
