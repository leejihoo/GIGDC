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

    public override void Cast()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.2f, 0.6f), Random.Range(0.2f, 0.8f), 10));
        if (!_isStart)
        {
            StartCoroutine(Landing());
        }
    }

    IEnumerator Landing()
    {
        _isStart = true;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        this.transform.GetComponent<CircleCollider2D>().enabled = true;
        GameObject.Find("Eagle").GetComponent<EagleSkill>().SkillRunnig = false;
        GameObject.Find("Eagle").GetComponent<EagleSkill>().IsDelay = false;
        GameObject.Find("Eagle").GetComponent<Animator>().SetBool("IsFlyOn", false);
        _isStart = false;
        GameObject.Find("Eagle").GetComponent<AudioSource>().Stop();
        gameObject.SetActive(false);
    }

}
