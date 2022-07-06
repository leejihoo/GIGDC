using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGrooming : SkillModel
{
    private int _shield;
    private bool _isStart;

    public CatGrooming()
    {
        Name = "Grooming";
        _shield = 30;
        _isStart = false;
    }

    public override void Cast()
    {
        gameObject.transform.SetParent(GameObject.Find("Cat").transform);
        gameObject.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStart)
        {
            StartCoroutine(WaitHealing());
        }
        
        if(_shield <= 0)
        {
            _shield = 30;
            gameObject.GetComponentInParent<Cat>().Hp -= 30;
            _isStart = false;
            GameObject.Find("Cat").GetComponent<CatSkill>().SkillRunnig = false;
            GameObject.Find("Cat").GetComponent<CatSkill>().IsDelay = false;
            GameObject.Find("Cat").GetComponent<Animator>().SetBool("IsGroomingOn", false);
            GameObject.Find("Cat").GetComponent<AudioSource>().Stop();
            gameObject.SetActive(false);
        }
    }

    IEnumerator WaitHealing()
    {
        _isStart = true;
        yield return new WaitForSeconds(5);
        gameObject.GetComponentInParent<Cat>().Hp += 30;
        GameObject.Find("Cat").GetComponent<CatSkill>().SkillRunnig = false;
        GameObject.Find("Cat").GetComponent<CatSkill>().IsDelay = false;

        _isStart = false;
        GameObject.Find("Cat").GetComponent<Animator>().SetBool("IsGroomingOn", false);
        GameObject.Find("Cat").GetComponent<AudioSource>().Stop();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.GetComponent<Animator>().SetTrigger("IsDamaged");
            // 유저의 총알에 맞았을 때
            _shield -= 1;
        }
        
    }
}
