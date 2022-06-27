using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CatChattering : SkillModel
{
    private float _speed;
    private bool _skillRunning;
    public CatChattering()
    {
        Name = "Chattering";    
    }

    // Update is called once per frame
    void Update()
    {

        if (!_skillRunning)
        {
            if (GameObject.Find("GlobalLight").GetComponent<Light2D>().intensity >= 0)
            {
                GameObject.Find("GlobalLight").GetComponent<Light2D>().intensity -= 0.002f;
            }
            else
            {
                GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
                //GameObject.Find("Cat").transform.GetChild(2).gameObject.SetActive(true);
                var _dir = GameObject.Find("Player").transform.position - GameObject.Find("Cat").transform.position;

                if (_dir.magnitude >= 0.1f)
                {
                    this.transform.parent.transform.Translate(_dir.normalized * Time.deltaTime * _speed);
                }
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _speed = 20;
        }
    }

    public override void Cast()
    {
        _speed = 5;
        gameObject.transform.SetParent(GameObject.Find("Cat").transform);
        gameObject.transform.localPosition = Vector3.zero;
        _skillRunning = false;
        StartCoroutine(ContinueSkill());
        
    }

    IEnumerator ContinueSkill()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("Cat").GetComponent<CatSkill>().SkillRunnig = false;
        GameObject.Find("Cat").GetComponent<CatSkill>().IsDelay = false;
        _skillRunning = true;
        GameObject.Find("Cat").transform.position = new Vector3(10, 0, 0);
        GameObject.Find("GlobalLight").GetComponent<Light2D>().intensity = 1;
        gameObject.SetActive(false);
    }

}
