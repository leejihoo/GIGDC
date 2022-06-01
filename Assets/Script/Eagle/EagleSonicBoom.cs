using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSonicBoom : SkillModel
{
    public EagleSonicBoom()
    {
        Name = "SonicBoom";
        IsCanParrying = true;
        Damage = 1;

    }

    public override void Cast()
    {
        this.transform.position =  Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0.5f, 0));
    }

    private void Start()
    {

        StartCoroutine(DelayNextAttack());
    }

    private void Update()
    {

    }

    IEnumerator DelayNextAttack()
    {
        this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0.5f, 0));
        yield return new WaitForSeconds(5);
        this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.25f, 0));
        yield return new WaitForSeconds(5);
        this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.75f, 0));
        yield return new WaitForSeconds(5);
        this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 0.5f, 0));
    }
}
