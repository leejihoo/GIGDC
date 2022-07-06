using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController_Shark : MonoBehaviour
{
    public Shark boss;
    public SkillModel[] skills;
    private bool isSkillRunning; 
    void Start()
    {
        skills = new SkillModel[4];

        for(int i = 0; i < 4; i++) {
            skills[i] = (Resources.Load("Prefab/Boss/SharkSkill_"+i) as GameObject).GetComponent<SkillModel>();
            Debug.Log(i);
        }

        StartCoroutine(SkillCycle());
    }
   public void SkillRun() {
        isSkillRunning = true;
        SkillModel newSkill = GameObject.Instantiate(skills[Random.Range(0,4)]);
        newSkill.shark = boss;
        newSkill.bossController_Shark = this;
        newSkill.dummy = GameObject.Find("dummy").gameObject;
        newSkill.defaultPoint = GameObject.Find("defaultPoint").transform;
        newSkill.hidePoint = GameObject.Find("hidePoint").transform;
        newSkill.returnPoint = GameObject.Find("returnPoint").transform;
        //newSkill.bossController = this;
    }

    IEnumerator SkillCycle() {
        Repeat :
        Debug.Log("Skill Play Start");
        SkillRun();
        while(isSkillRunning) {
            Debug.Log("Not Yet");
            yield return new WaitForSeconds(4.0f);
        }
        goto Repeat;
    }

    public void EndSkillPlaying() {
        Debug.Log("Stop");
        isSkillRunning = false;
    }
}
