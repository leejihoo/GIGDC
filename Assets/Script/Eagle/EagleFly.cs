using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFly : SkillModel
{
    private bool _isStart;
    private bool _isAttack;
    public EagleFly()
    {
        Name = "Fly";
        Damage = 2;
        IsCanParrying = false;
        _isStart = false;
        _isAttack = false;
    }

    private void Start()
    {
        // 클래스를 파괴하지 않고 enable만 조정한다면 bool값 갱신 필요
        //_isStart = false;
        //_isAttack = false;

        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 10));
        if (!_isStart)
        {
            StartCoroutine(Landing());
        }    
    }

    IEnumerator Landing()
    {
        _isStart = true;
        yield return new WaitForSeconds(3);
        this.transform.GetComponent<CircleCollider2D>().enabled = true;
        Debug.Log("쾅");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !_isAttack)
        {
            _isAttack = true;
            //데미지를 주는코드
            Debug.Log("데미지를 주었습니다");
        }        
    }

}
