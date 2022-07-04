using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHairBall : SkillModel
{
    int a;
    public CatHairBall()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public override void Cast()
    {
        gameObject.transform.SetParent(GameObject.Find("Cat").transform);
        //gameObject.transform.localPosition = Vector3.zero;
        StartCoroutine(ContinueSkill());
    }

    IEnumerator ContinueSkill()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("Cat").GetComponent<CatSkill>().SkillRunnig = false;
        GameObject.Find("Cat").GetComponent<CatSkill>().IsDelay = false;
        gameObject.SetActive(false);
    }
}
