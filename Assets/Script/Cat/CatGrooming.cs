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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStart)
        {
            Cast();
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
        _isStart = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 유저의 총알에 맞았을 때
        _shield -= 1;
    }
}
