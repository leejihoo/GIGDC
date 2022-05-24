using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class EagleSkill : SkillModel
{
    private Timer _timer;
    private bool _isPlayerIn;
    private bool _isStarted;

    public EagleSkill()
    {
        Name = "tornado";
        IsCanParrying = false;
        Damage = 1;
        HoldingTime = 5;
        _timer = new Timer();
        _timer.Interval = 1000;
        _timer.Elapsed += TickDamage;
        _isPlayerIn = false;
        _isStarted = true;
    }

    public override void Cast()
    {
        if (_isStarted)
        {
            StartCoroutine(holdingSkill());
        }

        var target = GameObject.FindGameObjectWithTag("Player");
        Vector3 dirForwardTornado = this.transform.position - target.transform.position;
        //target.GetComponent<Rigidbody2D>().AddForce(dirForwardTornado * Time.deltaTime, ForceMode2D.Force );
        target.transform.Translate(dirForwardTornado * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerIn = false;
        }
    }

    private void TickDamage(object sender, ElapsedEventArgs e)
    {
        if (_isPlayerIn)
        {
            //데미지를 주는 코드
            UnityEngine.Debug.Log("데미지를 입었습니다");
        }
    }

    private IEnumerator holdingSkill()
    {
        _timer.Start();
        _isStarted = false;
        yield return new WaitForSeconds(5);
        UnityEngine.Debug.Log("stop");
        _timer.Stop();
    }

    // 테스트용
    private void Update()
    {
        Cast();
    }
}
