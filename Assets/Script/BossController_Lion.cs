using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController_Lion : MonoBehaviour
{
    public LionPositionController boss;     
    public SkillModel[] skills;
    private bool isSkillRunning; 

    void Start()
    {
        skills = new SkillModel[4];

        for(int i = 0; i < 4; i++) {
            skills[i] = (Resources.Load("Prefab/Boss/LionSkill_"+i) as GameObject).GetComponent<SkillModel>();
            Debug.Log(i);
        }

        StartCoroutine(SkillCycle());
    }

    public void SkillRun() {
        isSkillRunning = true;
        SkillModel newSkill = GameObject.Instantiate(skills[Random.Range(0,4)]);
        newSkill.lionPosCon = boss;
        newSkill.bossController = this;
    }

    IEnumerator SkillCycle() {
        Repeat :
        Debug.Log("Skill Play Start");
        SkillRun();
        while(isSkillRunning) {
            Debug.Log("Not Yet");
            yield return new WaitForSeconds(1.0f);
        }
        goto Repeat;
    }

    public void EndSkillPlaying() {
        isSkillRunning = false;
    }
}
