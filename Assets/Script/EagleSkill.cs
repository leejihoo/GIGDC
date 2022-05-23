using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSkill : SkillModel
{
    
    public EagleSkill()
    {
        Name = "tornado";
        IsCanParrying = false;
        Damage = 1;
        HoldingTime = 5;
    }

    public override void Cast()
    {
        var target = GameObject.FindGameObjectWithTag("Player");
        Vector3 dirForwardTornado = this.transform.position - target.transform.position;
        target.GetComponent<Rigidbody2D>().AddForce(dirForwardTornado, ForceMode2D.Force);
    }

    // 테스트용
    //private void Update()
    //{
    //    Cast();
    //}
}
