using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class EagleTornado : SkillModel
{
    
    private bool _isStarted;
    private float _power;

    public EagleTornado()
    {
        Name = "tornado";
        IsCanParrying = false;
        Damage = 1;
        HoldingTime = 5;
        _isStarted = true;
        _power = 10f;

    }

    private IEnumerator holdingSkill()
    {
        
        _isStarted = false;
        yield return new WaitForSeconds(5);
        _isStarted = true;
        gameObject.SetActive(false);
        
    }

    public override void Cast()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -Camera.main.transform.position.z));        
    }

    public void Update()
    {
        if (_isStarted)
        {
            StartCoroutine(holdingSkill());
        }

        var target = GameObject.FindGameObjectWithTag("Player");
        Vector3 dirForwardTornado = this.transform.position - target.transform.position;
        //target.GetComponent<Rigidbody2D>().AddForce(dirForwardTornado * Time.deltaTime, ForceMode2D.Force );
        target.transform.Translate(dirForwardTornado.normalized * Time.deltaTime * _power);
    }
}
