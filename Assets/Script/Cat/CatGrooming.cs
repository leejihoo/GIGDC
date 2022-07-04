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
            _isStart = false;
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
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �Ѿ˿� �¾��� ��
        _shield -= 1;
    }
}
