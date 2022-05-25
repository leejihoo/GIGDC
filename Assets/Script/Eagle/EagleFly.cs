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
        // Ŭ������ �ı����� �ʰ� enable�� �����Ѵٸ� bool�� ���� �ʿ�
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
        Debug.Log("��");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !_isAttack)
        {
            _isAttack = true;
            //�������� �ִ��ڵ�
            Debug.Log("�������� �־����ϴ�");
        }        
    }

}
